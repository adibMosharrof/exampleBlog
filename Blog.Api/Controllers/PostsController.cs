using System.Linq;
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
			return _postsRepository.Get();
		}


	    protected override Post GetEntityByKey(int key)
	    {
	        return _postsRepository.Get(key);
	    }
	}
}