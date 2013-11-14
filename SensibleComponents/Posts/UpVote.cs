using System;
using SensibleComponents.Users;
using SensibleComponents;

namespace SensibleComponents.Posts
{
    public class UpVote : BaseComponent
    {
        public int ID { get; set; }
        public bool IsUp { get; set; }
        public User User { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}