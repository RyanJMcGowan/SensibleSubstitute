using SensibleComponents;
using SensibleComponents.Posts;
using System;
using System.Collections.Generic;
using SensibleComponents.Users;

namespace SensibleComponents.Comments
{
    public class Comment : BaseComponent
    {
        public Post Post { get; set; }
        public string CommentText { get; set; }
        public List<SpamFlag> Flags { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsApproved { get; set; }
        public bool IsSpam { get; set; }
        public bool IsMarkedAsSpam { get; set; }
        public bool IsReply { get; set; }
        public User User { get; set; }
        public Comment ReplyTo { get; set; }
    }
}