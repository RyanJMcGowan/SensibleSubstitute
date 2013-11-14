using System;
using SensibleComponents.Posts;
using SensibleComponents;

namespace SensibleComponents.Schedules
{
    public class Schedule : BaseComponent
    {
        public int ID { get; set; }
        public DateTime PublishDate { get; set; }
    }
}