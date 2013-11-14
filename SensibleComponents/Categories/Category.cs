using System.Collections.Generic;
using SensibleComponents.Posts;
using SensibleComponents;

namespace SensibleComponents.Categories
{
    public class Category : BaseComponent
    {
        public string URL { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public bool IsDeleted { get; set; }
    }
}