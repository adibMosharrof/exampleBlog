using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Blog.Api.Controllers
{
    public class PostsController : ODataController
    {
        PostsRepository postsRepository = new PostsRepository();
        private bool PostExists(int key)
        {
            return postsRepository.PostExists(key);
        }

        [EnableQuery]
        public IQueryable<Post> Get()
        {
            return postsRepository.Get();
        }

        [EnableQuery]
        public SingleResult<Post> Get([FromODataUri] int key)
        {
            IQueryable<Post> result = postsRepository.Get(key);
            return SingleResult.Create(result);
        }

        public IHttpActionResult Post(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            postsRepository.Post(post);
            return Created(post);
        }
	}
}