namespace Server.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> FindAll(Expression<Func<T, bool>> pression = null);

        T FindBy(params object[] keyValues);

        Task<T> FindByAsync(params object[] keyValues);

        void Insert(T entity);
        
        void Update(T entity);

        void Delete(T entity);
    }
}
