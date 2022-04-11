﻿using FitnessWeb.Models;
using System.Linq.Expressions;

namespace Fitness.Infrastracture
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] paths);
        void Save();

    }
}
