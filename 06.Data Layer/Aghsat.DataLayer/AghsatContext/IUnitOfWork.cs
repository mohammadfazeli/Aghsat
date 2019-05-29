using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Aghsat.Domain;
namespace Aghsat.DataLayer.AghsatContext
{
    public interface IUnitOfWork : IDisposable
    {

        int SaveAllChanges();
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        void MarkAsChanges<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void MarkAsDelete<TEntity>(TEntity entity) where TEntity : BaseEntity;

    }
}
