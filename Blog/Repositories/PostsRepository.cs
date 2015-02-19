using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class PostsRepository
    {

        BlogContext db = new BlogContext();
        public IQueryable<Post> Get()
        {
            return db.Posts;
        }
        public bool PostExists(int key)
        {
            return db.Posts.Any(p => p.Id == key);
        }

        public IQueryable<Post> Get(int key)
        {
            return db.Posts.Where(p => p.Id == key);
        }

        public int Post (Post post)
        {
            db.Posts.Add(post);
            return db.SaveChanges();
        }
    }
}
