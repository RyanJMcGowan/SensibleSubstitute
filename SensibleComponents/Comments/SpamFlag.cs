using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SensibleComponents.Users;
using SensibleComponents;

namespace SensibleComponents.Comments
{
    public class SpamFlag : BaseComponent
    {
        public User User { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}