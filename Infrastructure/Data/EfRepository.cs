namespace Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T> where T : class
    {
        protected readonly Context _context;
        public EfRepository(Context dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
