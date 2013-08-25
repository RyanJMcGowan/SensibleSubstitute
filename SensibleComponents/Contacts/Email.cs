﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensibleComponents.Contacts
{
    public class Email
    {
        public int ID { get; set; }
        public string EmailAddress { get; set; }
        public string DisplayName { get; set; }
        public bool IsValid { get; set; }
        public bool IsSubscribed { get; set; }
        public bool IsDoNotContact { get; set; }
    }
    public enum EmailType
    {
        Work,
        Personal,
        Unknown,
    }
}