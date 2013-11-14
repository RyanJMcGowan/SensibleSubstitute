using SensibleComponents.Schedules;
using SensibleService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensibleService.Repositories
{
    public class ScheduleRepository : BaseRepository<Schedule>
    {
        private PostContext db;

        public ScheduleRepository(PostContext context)
            : base(context)
        {
            this.db = context;
        }
    }
}