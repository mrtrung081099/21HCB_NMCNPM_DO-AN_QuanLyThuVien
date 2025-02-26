﻿using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class

    {
        protected RepositoryContext RepositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll() =>
                RepositoryContext.Set<T>()
                    .AsNoTracking();


        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
                    RepositoryContext.Set<T>()
                        .Where(expression)
                        .AsNoTracking();
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        public async Task<int> CountAll() => await RepositoryContext.Set<T>().CountAsync();

    }
}
