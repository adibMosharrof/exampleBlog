using System.Data.Entity;
using System.Linq;
using Blog.Models.DTO;
using Blog.Models.Entities;

namespace Blog.Models.Repositories
{
    public class PostsRepository
    {

        BlogContext db = new BlogContext();
        //public IQueryable<AllPostsDTO> Get()
        //{
        //    var posts= db.Posts.Select(p=> new AllPostsDTO()
        //    {
        //       Content = p.Content,
        //       Status = p.Status,
        //       Title = p.Title
        //    });
        //    return posts;
        //}
        //public IQueryable<PostDto> Get()
        public IQueryable<Post> Get()
        {
            var posts = db.Posts;
            return posts;
            //var postsDto = new List<PostDto>();
            //foreach (var post in posts)
            //{
            //   postsDto.Add( Mapper.Map<Post, PostDto>(post)); 
            //}
            //var output = postsDto.AsQueryable();
            //return output;
        } 
        public bool PostExists(int key)
        {
            return db.Posts.Any(p => p.Id == key);
        }

        public IQueryable<PostDto> Get(int key)
        {
            var post = db.Posts.Include(p=>p.Comments).Select(p=> new PostDto()
            {
               Content = p.Content,
               Status = p.Status,
               Title = p.Title
               //Comments = p.Comments
            });
            return post;
        }

        public int Post (Post post)
        {
            db.Posts.Add(post);
            return db.SaveChanges();
        }
    }
}
