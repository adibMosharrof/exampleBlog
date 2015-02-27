using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using Blog.Models.Entities;
using Blog.Models.Repositories;

namespace Blog.Api.Controllers
{
	public class PostsController : EntitySetController<Post, int>
	{
	    private readonly IPostsRepository _postsRepository ;

	    public PostsController(PostsRepository postsPostsRepository)
	    {
	        _postsRepository = postsPostsRepository;
	    }
		private bool PostExists(int key)
		{
			return _postsRepository.Exists(key);
		}

        public override IQueryable<Post> Get()
        {
            return _postsRepository.All();
        }

	    protected override Post GetEntityByKey(int key)
        {
            var post = _postsRepository.Get(key);
            return post;
        }

          [AcceptVerbs("PATCH", "MERGE")]
	    public override HttpResponseMessage Patch(int key, Delta<Post> patch)
	    {
	        var post = _postsRepository.Patch(key, patch);
	        if (post == null)
	            return Request.CreateResponse(HttpStatusCode.NotFound);
	        return Request.CreateResponse(Updated(post));
	    }

	    public override HttpResponseMessage Post(Post entity)
	    {
	        _postsRepository.Create(entity);
	        return Request.CreateResponse(HttpStatusCode.OK);
	    }

	    public IQueryable<Comment> GetComments(int key)
	    {
	        return _postsRepository.GetComments(key);
	    } 
	}
}