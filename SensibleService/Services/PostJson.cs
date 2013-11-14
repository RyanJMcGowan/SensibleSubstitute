using SensibleComponents.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensibleService.Models
{
    public class PostJson
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public string URL { get; set; }
        public DateTime LastEdited { get; set; }
        public int Views { get; set; }

        public PostJson(Post post)
        {
            this.Title = post.Title;
            this.Contents = post.Contents;
            this.URL = post.URL;
            this.LastEdited = post.LastEdited;
            this.Views = post.Views;
        }
    }
}