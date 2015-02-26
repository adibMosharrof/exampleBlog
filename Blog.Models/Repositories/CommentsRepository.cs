using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models.Entities;

namespace Blog.Models.Repositories
{
    public class CommentsRepository
    {
        BlogContext db = new BlogContext();

        public IQueryable<Comment> Get()
        {
            return db.Comments;
        }
    }
}
