using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensibleComponents.Contacts
{
    public class Address
    {
        public int ID { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool IsPublic { get; set; }
        public bool IsMailing { get; set; }
    }
}