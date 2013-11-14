using SensibleComponents.Comments;
using SensibleService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensibleService.Repositories
{
    public class CommentRepository : BaseRepository<Comment>
    {
        private PostContext db;

        public CommentRepository(PostContext context)
            : base(context)
        {
            this.db = context;
        }
    }
}