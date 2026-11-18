using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trade_Site_Comments.Context;
using Trade_Site_Comments.DTOs;
using Trade_Site_Comments.Entity;

namespace Trade_Site_Comments.Services
{
    public class CommentService : ICommentService
    {
        private readonly Db_Context _context;
        private readonly IMapper _mapper;

        public CommentService(Db_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddComment(AddCommentDto addCommentDto)
        {
            var value = _mapper.Map<Comment>(addCommentDto);
            _context.Set<Comment>().Add(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComment(int id)
        {
            var value = await _context.Set<Comment>().FindAsync(id);
            if (value != null)
            {
                _context.Set<Comment>().Remove(value);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ShowCommentDto>> GetCommentAll()
        {
            var values = await _context.Set<Comment>().ToListAsync();
            return _mapper.Map<List<ShowCommentDto>>(values);
        }

        public async Task<ShowCommentDto> GetCommentById(int id)
        {
            var value = await _context.Set<Comment>().FindAsync(id);
            return _mapper.Map<ShowCommentDto>(value);
        }

        public async Task<List<GetCommentWithProductID>> GetCommentWithProduct(string id)
        {
            var value = await _context.Set<Comment>().Where(c => c.ProductID == id)
                .ToListAsync();
            return _mapper.Map<List<GetCommentWithProductID>>(value);
        }

        public async Task Update(UpdateCommentDto updateCommentDto)
        {
            var value = _mapper.Map<Comment>(updateCommentDto);
            _context.Set<Comment>().Update(value);
            await _context.SaveChangesAsync();
        }
    }
}
