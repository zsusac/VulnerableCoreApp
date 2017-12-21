using System;

namespace VulnerableCoreApp.ViewModels
{
    public class CommentViewModel
    {
        public String ID { get; set; }
        public String Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public String Text { get; set; }
    }
}