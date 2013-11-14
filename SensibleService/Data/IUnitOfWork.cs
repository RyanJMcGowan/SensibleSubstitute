using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensibleService;
using SensibleComponents;

namespace SensibleService
{
    interface IUnitOfWork
    {
        void Dispose();
        void Save();
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : IComponent;
    }
}
