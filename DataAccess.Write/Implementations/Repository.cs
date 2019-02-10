using System;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Write.Abstractions;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Write.Implementations
{
    using System.Collections.Generic;

    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<T> GetCollectionByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity
        {
            return _context.Set<T>().Where(filter).ToList();
        }

        public ICollection<T> GetAll<T>()
            where T : BaseEntity
        {
            return _context.Set<T>().ToList();
        }

        public ICollection<T> GetCollectionByFilterWithChildren<T>(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
            where T : BaseEntity
        {
            var collection = _context.Set<T>().Where(filter);
            foreach (var includeProperty in includeProperties)
            {
                collection = collection.Include(includeProperty);
            }

            return collection.ToList();
        }

        public T GetByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity
        {
            return _context.Set<T>().FirstOrDefault(filter);
        }

        public void Insert<T>(T entity)
            where T : BaseEntity
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Update<T>(T entity)
            where T : BaseEntity
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete<T>(T entity)
            where T : BaseEntity
        {
            _context.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}