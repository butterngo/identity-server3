namespace Server.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Linq.Expressions;

    public abstract  class Repository<T, C> : IRepository<T> where T : class where C : IdentityServerContext, new()
    {
        private C _context ;

        public Repository() : this(new C()) { }

        public Repository(C context)
        {
            _context = context;
        }

        public virtual  void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;

        }
       
        public virtual T FindBy(params object[] keyValues)
        {
            return _context.Set<T>().Find(keyValues);
        }

        public virtual IQueryable<T> FindAll(Expression<Func<T, bool>> pression = null)
        {
            if (pression == null)
            {
                IQueryable<T> query = _context.Set<T>();

                return query;
            }
            else
            {
                IQueryable<T> query = _context.Set<T>().Where(pression);

                return query;
            }
            
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<T> FindByAsync(params object[] keyValues)
        {
            return await _context.Set<T>().FindAsync(keyValues);
        }

    }
}