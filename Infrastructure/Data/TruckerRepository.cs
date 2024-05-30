using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class TruckerRepository : EfRepository<Trucker>, ITruckerRepository
    {
        public TruckerRepository(Context context) : base(context) { }
    }
}
