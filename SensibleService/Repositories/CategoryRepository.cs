using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SensibleComponents;
using SensibleComponents.Categories;
using SensibleService;
using System.Data.Entity;
using SensibleService.Data;

namespace SensibleService.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        private PostContext db;

        public CategoryRepository(PostContext context) : base(context)
        {
            this.db = context;
        }

        public override bool Delete(int id)
        {
            Category c = db.Categories.Find(id);
            if (c == null)
                throw new NullReferenceException("Category not found.");
            c.IsDeleted = true;
            if (db.SaveChanges() == 1)
                return true;
            return false;
        }

        public Category GetByName(string name)
        {
            return db.Categories.Where(c => c.Name == name).FirstOrDefault();
        }
 
    }
}