namespace Server.Repository
{
    public class GenericRepository<T, C> : Repository<T, C>, IRepository<T> where T : class where C : IdentityServerContext, new()
    {
        public GenericRepository() : base(new C()) { }
        public GenericRepository(C context) : base(context) { }
    }
}