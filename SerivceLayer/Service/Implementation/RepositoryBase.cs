using Microsoft.EntityFrameworkCore;
using RepositoryLayer.DbContextLayer;
using SerivceLayer.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SerivceLayer.Service.Implementation
{
    public abstract class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        public ApplicationDbContext dbContext { get; set; }

        public  RepositoryBase(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public IQueryable<T> FindAll()
        {
            return this.dbContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.dbContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.dbContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.dbContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.dbContext.Set<T>().Remove(entity);
        }
    }
}
