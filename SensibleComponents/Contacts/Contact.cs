using SensibleComponents.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensibleComponents.Contacts
{
    public class ContactInfo : BaseComponent
    {
        public ContactType ContactType { get; set; }
        public List<Address> Addresses { get; set; }
        public Phone PrimaryPhoneNumber { get; set; }
        public Phone SecondaryPhoneNumber { get; set; }
        public List<Email> Emails { get; set; }
        public string TwitterCallsign { get; set; }
        public Email PrimaryEmail { get { return Emails.Where(e => e.IsPrimary).FirstOrDefault(); } }
        public Address PrimaryAddress { get { return Addresses.Where(e => e.IsPrimary).FirstOrDefault(); } }

        public bool MakeAddressCurrent(Address address)
        {
            foreach (Address a in this.Addresses)
            {
                a.IsPrimary = false;
            }
            address.IsPrimary = true;
            return true;
        }

        public bool MakeEmailCurrent(Email email)
        {
            foreach (Email e in this.Emails)
            {
                e.IsPrimary = false;
            }
            email.IsPrimary = true;
            return true;
        }

    }

    public enum ContactType
    {
        Home,
        Office,
        Employer,
        Other
    }
}