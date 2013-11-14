using System.Collections.Generic;
using SensibleComponents.Comments;
using SensibleComponents.Categories;
using SensibleComponents.Authors;
using SensibleComponents.Tags;
using SensibleComponents.Schedules;
using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SensibleComponents.Posts
{
    public class Post : BaseComponent, IPost
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public string URL { get; set; }
        [JsonIgnore]
        public List<Comment> Comments { get; set; }
        [JsonIgnore]
        public List<Category> Categories { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }
        public DateTime LastEdited { get; set; }
        [JsonIgnore]
        public List<Tag> Tags { get; set; }
        [JsonIgnore]
        public Schedule Schedule { get; set; }
        [JsonIgnore]
        public int Views { get; set; }
        [JsonIgnore]
        public List<UpVote> UpVotes { get; set; }
    }
}