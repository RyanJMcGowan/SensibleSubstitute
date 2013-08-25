using System.Collections.Generic;
using SensibleComponents.Posts;

namespace SensibleComponents.Categories
{
    public class Category
    {
        public int ID { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int Count { get; set; }
        public List<Post> Posts { get; set; }
    }
}