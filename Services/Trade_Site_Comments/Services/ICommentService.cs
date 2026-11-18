using Trade_Site_Comments.DTOs;

namespace Trade_Site_Comments.Services
{
    public interface ICommentService
    {
        public Task AddComment(AddCommentDto addCommentDto);
        public Task Update(UpdateCommentDto updateCommentDto);
        public Task<List<ShowCommentDto>> GetCommentAll();
        public Task<List<GetCommentWithProductID>> GetCommentWithProduct(string id);
        public Task<ShowCommentDto> GetCommentById(int id);
        public Task DeleteComment(int id);
    }
}
