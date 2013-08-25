using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensibleComponents.Comments
{
    public class Comment
    {
        public int ID { get; set; }
        public string CommentText { get; set; }
        public bool IsSpam { get; set; }
        public bool IsMarkedAsSpam { get; set; }
        public List<SpamFlag> Flags { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsApproved { get; set; }
    }
}