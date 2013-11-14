using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensibleComponents
{
    public abstract class BaseComponent : IComponent
    {
        public int ID { get; set; }
    }
}