using SensibleComponents.Authors;
using SensibleService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensibleService.Repositories
{
    public class AuthorRepository : BaseRepository<Author>
    {
        private PostContext db;

        public AuthorRepository(PostContext context)
            : base(context)
        {
            this.db = context;
        }
    }
}