namespace Trade_Site_Comments.DTOs
{
    public class AddCommentDto
    {
        public string NameSurname { get; set; }
        public string? ImgUrl { get; set; }
        public string Email { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public DateTime CommentDate { get; set; }
        public string ProductID { get; set; }
    }
}
