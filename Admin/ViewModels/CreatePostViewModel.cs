using SensibleComponents.Authors;
using SensibleComponents.Categories;
using SensibleComponents.Schedules;
using SensibleComponents.Tags;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.ViewModels
{
    public class CreatePostViewModel
    {
        [Required]
        public string Title { get; set; }
        public string Contents { get; set; }
        public List<Category> Categories { get; set; }
        public Author Author { get; set; }
        public List<Tag> Tags { get; set; }
    }
}