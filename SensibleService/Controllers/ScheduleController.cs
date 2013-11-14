using SensibleComponents.Schedules;
using SensibleService.Data;
using SensibleService.Repositories;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace SensibleService.Controllers
{
    public class ScheduleController : ApiController
    {
        private ScheduleRepository db = new ScheduleRepository(new PostContext());

        // GET api/schedule
        public IEnumerable<Schedule> Get()
        {
            List<Schedule> list = new List<Schedule>();
            db.GetAll();
            return list;
        }

        // GET api/schedule/5
        public Schedule Get(int id)
        {
            Schedule schedule = db.GetByID(id);
            if (schedule == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return schedule;
        }

        // POST api/schedule
        public HttpResponseMessage Post(Schedule schedule)
        {
            if (db.Update(schedule))
                return Request.CreateResponse(HttpStatusCode.Accepted);
            return Request.CreateResponse(HttpStatusCode.BadRequest);
            
        }

        // PUT api/schedule/5
        public HttpResponseMessage Put(Schedule schedule)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        // DELETE api/schedule/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }
    }
}
