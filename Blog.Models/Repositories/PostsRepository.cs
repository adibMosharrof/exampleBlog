using System.Data.Entity;
using System.Linq;
using Blog.Models.Entities;

namespace Blog.Models.Repositories
{
    public class PostsRepository : GenericRepository<Post>,IPostsRepository
    {

        private readonly BlogContext _db;

        public PostsRepository(BlogContext blogContext)
        {
            _db = blogContext;
        }

        public IQueryable<Comment> GetComments(int key)
        {
            return _db.Comments.Where(p => p.PostId == key);
        }
    }
}
