using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models.Entities;

namespace Blog.Models.Repositories
{
    public interface IPostsRepository : IGenericRepository<Post>
    {
        IQueryable<Comment> GetComments(int key);
    }
}
