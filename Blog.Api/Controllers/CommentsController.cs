using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using Blog.Models.Entities;
using Blog.Models.Repositories;
using Microsoft.Data.OData;

namespace Blog.Api.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using Blog.Models.Entities;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Comment>("Comments");
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CommentsController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        CommentsRepository commentsRepository = new CommentsRepository();

        // GET: odata/Comments
        public IHttpActionResult GetComments(ODataQueryOptions<Comment> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }
            var comments = commentsRepository.Get();

            return Ok(comments);
        }

        // GET: odata/Comments(5)
        public IHttpActionResult GetComment([FromODataUri] int key, ODataQueryOptions<Comment> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Comment>(comment);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Comments(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Comment> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(comment);

            // TODO: Save the patched entity.

            // return Updated(comment);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Comments
        public IHttpActionResult Post(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(comment);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Comments(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Comment> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(comment);

            // TODO: Save the patched entity.

            // return Updated(comment);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Comments(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
