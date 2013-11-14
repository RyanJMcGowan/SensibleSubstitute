using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SensibleComponents;
using SensibleComponents.Posts;
using SensibleService;
using System.Data.Entity;
using SensibleService.Data;

namespace SensibleService.Repositories
{
    public class PostRepository : BaseRepository<Post>
    {
        private PostContext db;
        
        //TODO: Delete the generics

        public PostRepository(PostContext context) : base(context)
        {
            this.db = context;
        }

        public IQueryable<Post> GetRange(DateTime beginTime, DateTime endTime)
        {
            IQueryable<Post> posts = db.Posts.Where(p => 
                p.Schedule.PublishDate > beginTime 
                && p.Schedule.PublishDate < endTime);
            return posts;
        }

        // TODO: Move to Base
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }
    }
}