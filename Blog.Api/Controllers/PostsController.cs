using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http.OData;
using Blog.Models.Entities;
using Blog.Models.Repositories;

namespace Blog.Api.Controllers
{
	//[Queryable]
	//public class PostsController : EntitySetController<PostDto, int>
	public class PostsController : EntitySetController<Post, int>
	//public class PostsController : ODataController
	{
		PostsRepository postsRepository = new PostsRepository();
		private bool PostExists(int key)
		{
			return postsRepository.PostExists(key);
		}

		public override IQueryable<Post> Get()
		//public override  IQueryable<PostDto> Get()
		{
			return postsRepository.Get();
		}


		//public SingleResult<OnePostDto> Get([FromODataUri] int key)
		//{
		//    IQueryable<OnePostDto> result = postsRepository.Get(key);
		//    return SingleResult.Create(result);
		//}

		//public IHttpActionResult Post(Post post)
		//{
		//    if (!ModelState.IsValid)
		//    {
		//        return BadRequest(ModelState);
		//    }
		//    postsRepository.Post(post);
		//    return Created(post);
		//}
	}
}