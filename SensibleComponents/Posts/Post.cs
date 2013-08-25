using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SensibleComponents.Comments;
using SensibleComponents.Categories;
using SensibleComponents.Authors;
using SensibleComponents.Tags;
using SensibleComponents.Schedules;

namespace SensibleComponents.Posts
{
    public class Post : IPost
    {
        public int ID { get; set; }
        public string Contents { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Category> Categories { get; set; }
        public Author Author { get; set; }
        public List<Tag> Tags { get; set; }
        public Schedule Schedule { get; set; }
    }
}