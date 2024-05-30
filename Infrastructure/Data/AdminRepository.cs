using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class AdminRepository : EfRepository<Admin>, IAdminRepository
    {
        public AdminRepository(Context context) : base(context) { }
    }


}
