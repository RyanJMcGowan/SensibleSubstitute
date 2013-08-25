using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensibleComponents.Contacts
{
    public class Contact
    {
        public int ID { get; set; }
        public string ContactTitle { get; set; }
        public List<Address> Adresses { get; set; }
        private int PrimaryAddressID { get; set; }
        public Address PrimaryAddress { get; set; }
        public Phone PrimaryPhoneNumber { get; set; }
        public Phone SecondaryPhoneNumber { get; set; }
        public List<Email> Emails { get; set; }
    }
}