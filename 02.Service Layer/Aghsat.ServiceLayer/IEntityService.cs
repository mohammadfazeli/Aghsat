﻿using Aghsat.DataLayer.AghsatContext;
using Aghsat.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aghsat.ServiceLayer
{
    public interface IEntityService<T>
    {

        AddStatus Create(T entity);
        DeleteStatus delete(int? id);
        IEnumerable<T> GetAll();
        updateStatus Update(T entity);
        T GetByID(int id);
    }

    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {

        protected IUnitOfWork _uow;
        protected readonly IDbSet<T> _dbset;

        protected EntityService(IUnitOfWork uow)
        {
            _uow = uow;
            _dbset = _uow.Set<T>();

        }

        public abstract AddStatus Create(T entity);
        public abstract DeleteStatus delete(int? id);
        public abstract IEnumerable<T> GetAll();
        public T GetByID(int id) { return _dbset.Find(id); }
        public abstract updateStatus Update(T entity);
    }
}
