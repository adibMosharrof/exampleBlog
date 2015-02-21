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

namespace Blog.Api.Controllers
{
    [EnableQuery]
    public class PostsController : EntitySetController<Post, int>
    {
        PostsRepository postsRepository = new PostsRepository();
        private bool PostExists(int key)
        {
            return postsRepository.PostExists(key);
        }

        public override IQueryable<Post> Get()
        {
            return postsRepository.Get();
        }

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