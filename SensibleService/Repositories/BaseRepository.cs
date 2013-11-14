using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SensibleComponents;
using System.Data.Entity;

namespace SensibleService.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseComponent
    {
        private DbSet<T> _set { get; set; }
        private DbContext _context;

        public BaseRepository(DbContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
            _set = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return (IQueryable<T>)_set;
        }

        public T GetByID(int id)
        {
            return (T)_set.Find(id);
        }

        public List<T> GetByID(IEnumerable<int> ids)
        {
            List<T> set = new List<T>();
            foreach(int id in ids)
            {
                set.Add((T)_set.Where(i => i.ID == id));
            }
            return set;
        }

        public bool Insert(T entity)
        {
            if(_set.Add(entity) != null)
                return true;
            return false;
        }

        public bool Update(T entity)
        {
            _set.Attach(entity);
            _context.Entry(entity).State = System.Data.EntityState.Modified;
            return true;
        }

        public virtual bool Delete(int id)
        {
            _set.Remove(_set.Find(id));
            return true;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}