﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensibleProfiles.Profiles
{
    public class Profile
    {
        public int ID { get; set; }
        public Member User { get; set; }
    }
}