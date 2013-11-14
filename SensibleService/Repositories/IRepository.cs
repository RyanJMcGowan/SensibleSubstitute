using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SensibleComponents;

namespace SensibleService
{
    public interface IRepository<TEntity> where TEntity:IComponent
    {
        IQueryable<TEntity> GetAll();
        TEntity GetByID(int id);
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(int id);
        int SaveChanges();
    }
}