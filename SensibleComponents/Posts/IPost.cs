using System.Collections.Generic;
using SensibleComponents.Comments;
using SensibleComponents.Categories;
using SensibleComponents.Authors;
using SensibleComponents.Tags;

namespace SensibleComponents.Posts
{
    interface IPost
    {
        int ID { get; set; }
        //List<Comment> Comments { get; set; }
        List<Category> Categories { get; set; }
        Author Author { get; set; }
        List<Tag> Tags { get; set; }
    }
}
