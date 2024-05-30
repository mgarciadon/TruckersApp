using Domain.Entities;
using Domain.Enums;

namespace Domain.Interfaces
{
    public interface ITripRepository : IRepositoryBase<Trip>
    {
        ICollection<Trip> GetByStatus(TripStatus status);
        ICollection<Trip> GetByTruckerId(int truckerId);

        ICollection<Trip> Get();
    }
}
