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

        public int Post (Post post)
        {
            _db.Posts.Add(post);
            return _db.SaveChanges();
        }
    }
}
