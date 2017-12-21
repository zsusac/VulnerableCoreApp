using System;

namespace VulnerableCoreApp.Models
{
    public class Comment
    {
        public String ID { get; set; }
        public String Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public String Text { get; set; }
    }
}