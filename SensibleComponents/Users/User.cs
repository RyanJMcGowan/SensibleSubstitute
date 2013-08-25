using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SensibleComponents.Comments;

namespace SensibleComponents.Users
{
    public class User : IUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Comment> Comments { get; set; }
        public bool IsBanned { get; set; }
        public bool IsLocked { get; set; }
        public bool IsApproved { get; set; }
    }
}