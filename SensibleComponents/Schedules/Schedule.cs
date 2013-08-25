using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SensibleComponents.Posts;

namespace SensibleComponents.Schedules
{
    public class Schedule
    {
        public int ID { get; set; }
        public Post Post { get; set; }
        public DateTime PublishDate { get; set; }
    }
}