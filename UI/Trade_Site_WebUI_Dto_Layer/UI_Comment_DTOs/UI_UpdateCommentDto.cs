using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_WebUI_Dto_Layer.UI_Comment_DTOs
{
    public class UI_UpdateCommentDto
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
