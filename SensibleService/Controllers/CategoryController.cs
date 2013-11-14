using SensibleComponents.Categories;
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
    public class CategoryController : ApiController
    {
        private CategoryRepository db = new CategoryRepository(new PostContext());

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            IEnumerable<Category> category = db.GetAll().ToArray().OrderBy(c => c.Name);
            if (category == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return category;
        }

        [HttpGet]
        public Category Get(int id)
        {
            Category category = db.GetByID(id);
            if (category == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return category;
        }

        [Authorize]
        [HttpPost]
        public HttpResponseMessage Post(Category category)
        {
            if (category.Name == "")
                return Request.CreateResponse(HttpStatusCode.BadRequest, "A complete category model is required.");

            if (!CategoryServices.IsComplete(category))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            if (db.GetByName(category.Name) == null)
            {
                if(db.Insert(category))
                {
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
            }
            if(db.Update(category))
                return Request.CreateResponse(HttpStatusCode.Accepted);
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        [Authorize]
        [HttpGet]
        public HttpResponseMessage Seed()
        {
            if(db.GetAll().Count() >= 4)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Categories have already been created.");
            List<Category> categories = new List<Category>();
            for (int i = 1; i <= 5; i++)
            {
                Category category = new Category();
                category.ID = i;
                if (i == 1)
                    category.Name = "General";
                if (i == 2)
                    category.Name = "Interesting";
                if (i == 3)
                    category.Name = "Students";
                if (i == 4)
                    category.Name = "Homework";
                if (i == 5)
                    category.Name = "Stress";
                category.Order = i;
                category.URL = "/Category/" + category.Name;

                db.Insert(category);
            }
            if (db.SaveChanges() == 5)
                return Request.CreateResponse(HttpStatusCode.Created);
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "An error occured while inserting data into the database.");
        }
    }
}
