using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository
{
    public abstract class RepositoryBase<T>: IRepositoryBase<T> where T:class
    {
        protected ZipcoContext ZipcoContext;

        protected RepositoryBase(ZipcoContext zipcoContext)
        {
            ZipcoContext = zipcoContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
             !trackChanges ? ZipcoContext.Set<T>().AsNoTracking()
            : ZipcoContext.Set<T>();


        public  IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
           !trackChanges
                ? ZipcoContext.Set<T>().Where(expression).AsNoTracking()
                : ZipcoContext.Set<T>()
                    .Where(expression);


        public async Task CreateAsync(T entity) => await ZipcoContext.Set<T>().AddAsync(entity);

    }
}
