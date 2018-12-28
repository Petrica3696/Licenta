using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Write.Abstractions
{
    public interface IRepository
    {
        ICollection<T> GetCollectionByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity;

        ICollection<T> GetAll<T>()
            where T : BaseEntity;

        T GetByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity;

        ICollection<T> GetCollectionByFilterWithChildren<T>(Expression<Func<T, bool>> filter,
            params Expression<Func<T, object>>[] includeProprieties)
            where T : BaseEntity;

        void Insert<T>(T entity)
            where T : BaseEntity;

        void Update<T>(T entity)
            where T : BaseEntity;

        void Save();
    }
}
