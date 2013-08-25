using System.Collections.Generic;
using SensibleComponents.Authors;
using SensibleComponents.Posts;

namespace SensibleComponents.Blogs
{
    public class Blog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public List<Post> Posts { get; set; }

    }
}