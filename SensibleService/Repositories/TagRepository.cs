using SensibleComponents.Tags;
using SensibleService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensibleService.Repositories
{
    public class TagRepository : BaseRepository<Tag>
    {
        private PostContext db;

        public TagRepository(PostContext context)
            : base(context)
        {
            this.db = context;
        }
    }
}