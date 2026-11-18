using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;
using Trade_Site_WebUI_Dto_Layer.UI_Auth_DTOs;

namespace Trade_Site_WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public AccountController(IHttpClientFactory httpClientFactory, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UI_LoginRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Development-only admin shortcut. Credentials come from configuration (user-secrets:
            // DevAdmin:Username / DevAdmin:Password), never from code; with no values set it is disabled.
            var devAdminUsername = _configuration["DevAdmin:Username"];
            var devAdminPassword = _configuration["DevAdmin:Password"];

            if (_environment.IsDevelopment() &&
                !string.IsNullOrEmpty(devAdminUsername) &&
                !string.IsNullOrEmpty(devAdminPassword) &&
                string.Equals(model.UsernameOrEmail, devAdminUsername, StringComparison.OrdinalIgnoreCase) &&
                model.Password == devAdminPassword)
            {
                var adminResponse = new UI_AuthResponseDto
                {
                    UserId = "admin-local",
                    Username = devAdminUsername,
                    Role = "Admin",
                    Token = "admin-local-token",
                    ExpiresAt = DateTime.UtcNow.AddHours(8)
                };

                await SignInUserAsync(adminResponse);
                return RedirectToAction("AdminCategoryIndex", "AdminCategory", new { area = "AdminArea" });
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7060/api/Auth/login", model);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Giris basarisiz. Bilgilerinizi kontrol edin.");
                return View(model);
            }

            var authResponse = await response.Content.ReadFromJsonAsync<UI_AuthResponseDto>();
            if (authResponse == null)
            {
                ModelState.AddModelError("", "Token bilgisi alinamadi.");
                return View(model);
            }

            await SignInUserAsync(authResponse);
            return RedirectToAction("CustomerScreenIndex", "CustomerScreen");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UI_RegisterRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7060/api/Auth/register", model);

            if (!response.IsSuccessStatusCode)
            {
                var errorText = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", string.IsNullOrWhiteSpace(errorText) ? "Kayit islemi basarisiz." : errorText);
                return View(model);
            }

            var authResponse = await response.Content.ReadFromJsonAsync<UI_AuthResponseDto>();
            if (authResponse == null)
            {
                ModelState.AddModelError("", "Token bilgisi alinamadi.");
                return View(model);
            }

            await SignInUserAsync(authResponse);
            return RedirectToAction("CustomerScreenIndex", "CustomerScreen");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("CustomerScreenIndex", "CustomerScreen");
        }


        private async Task SignInUserAsync(UI_AuthResponseDto authResponse)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, authResponse.UserId),
                new(ClaimTypes.Name, authResponse.Username),
                new("access_token", authResponse.Token)
            };

            if (!string.IsNullOrWhiteSpace(authResponse.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, authResponse.Role));
            }

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = authResponse.ExpiresAt
                });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Me()
        {
            var token = User.FindFirst("access_token")?.Value;

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Token bulunamadi.");
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("https://localhost:7060/api/Auth/me");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            var json = await response.Content.ReadAsStringAsync();
            return Content(json, "application/json");
        }
    }
}
