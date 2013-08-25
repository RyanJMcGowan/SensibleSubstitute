using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Membership.Models;
using SensibleComponents.Contacts;

namespace SensibleComponents.Authors
{
    public class Author
    {
        public int ID { get; set; }
        public Contact ContacntInfo { get; set; }
        public UserProfile Member { get; set; }
    }
}