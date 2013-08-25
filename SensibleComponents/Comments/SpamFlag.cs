using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SensibleComponents.Users;

namespace SensibleComponents.Comments
{
    public class SpamFlag
    {
        public User User { get; set; }
        public Comment Comment { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}