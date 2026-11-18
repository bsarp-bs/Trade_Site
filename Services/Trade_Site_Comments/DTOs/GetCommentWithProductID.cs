namespace Trade_Site_Comments.DTOs
{
    public class GetCommentWithProductID
    {
        public int CommentID { get; set; }
        public string NameSurname { get; set; }
        public string? ImgUrl { get; set; }
        public string Email { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public DateTime CommentDate { get; set; }
        public string ProductID { get; set; }
    }
}
