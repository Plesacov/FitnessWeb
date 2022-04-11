﻿using FitnessWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Fitness.Infrastracture
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private FitnessContext _context = null;
        private DbSet<T> table = null;
        public Repository()
        {
            this._context = new FitnessContext();
            table = _context.Set<T>();
        }
        public Repository(FitnessContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] paths)
        {
            IQueryable<T> queryable = this.table.Where(predicate);
            if (paths != null)
            {
                queryable = paths.Aggregate(queryable, (current, path) => current.Include(path));
            }
            return queryable.AsEnumerable();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> queryable = this.table.Where(predicate);
            return queryable.AsEnumerable();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
