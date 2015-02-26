using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Entities
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public String Title { get; set; }
        public String Content { get; set; }

        public int Status { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } 
    }
}
