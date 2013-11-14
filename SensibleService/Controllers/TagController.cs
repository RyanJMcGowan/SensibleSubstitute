using SensibleComponents.Tags;
using SensibleService.Data;
using SensibleService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SensibleService.Controllers
{
    public class TagController : ApiController
    {
        private TagRepository db = new TagRepository(new PostContext());

        // GET api/tag/
        public IEnumerable<Tag> Get(IEnumerable<int> ids)
        {
            List<Tag> tags = db.GetByID(ids);
            if (tags == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return tags;
        }

        // GET api/tag/5
        public Tag Get(int id)
        {
            Tag tag = db.GetByID(id);
            if (tag == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return tag;
        }

        // POST api/tag
        public HttpResponseMessage Post(Tag tag)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        // PUT api/tag/5
        public HttpResponseMessage Put(Tag tag)
        {
            //TODO: Validation

            if(db.Insert(tag))
                return Request.CreateResponse(HttpStatusCode.Created);
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE api/tag/5
        public HttpResponseMessage Delete(int id)
        {

            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        public HttpResponseMessage Seed()
        {
            List<Tag> tags = new List<Tag>();
            /*
            for (int i = 1; i <= 5; i++)
            {
                Tag tag = new Tag();
                tag.ID = i;
                if (i == 1)
                    tag.Name = "techniques";
                //TODO: Add posts
                if (i == 2)
                    tag.Name = "assignments";
                if (i == 3)
                    tag.Name = "ideas";
                if (i == 4)
                    tag.Name = "stress";
                if (i == 5)
                    tag.Name = "reinforcements";

                db.Insert(tag);
            }
            */
            return Request.CreateResponse(HttpStatusCode.MethodNotAllowed);
        }
    }
}
