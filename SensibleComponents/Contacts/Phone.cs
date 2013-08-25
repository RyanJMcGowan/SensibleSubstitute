using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensibleComponents.Contacts
{
    public class Phone
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public int CountryCode { get; set; }
        public int Extension { get; set; }
    }
}