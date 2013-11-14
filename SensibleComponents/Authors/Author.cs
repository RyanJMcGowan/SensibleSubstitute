using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SensibleMembership.Models;
using SensibleComponents.Contacts;

namespace SensibleComponents.Authors
{
    public class Author : BaseComponent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ContactInfo ContacntInfo { get; set; }
    }
}