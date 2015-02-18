using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class Post
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Status { get; set; }
    }
}
