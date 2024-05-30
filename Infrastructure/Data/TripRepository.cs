using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TripRepository : EfRepository<Trip>, ITripRepository
    {
        public TripRepository(Context context) : base(context) { }

        public ICollection<Trip> GetByStatus(TripStatus status)
        {
            var result = _context.Trips.Include(t => t.Truckers).Include(t => t.UserCreation).Where(t => t.TripStatus == status).ToList();
            return result;
        }

        public ICollection<Trip> GetByTruckerId(int truckerId)
        {
            var trips = _context.Trips
                .Include(t => t.UserCreation)
                .Where(t => t.Truckers.Any(trucker => trucker.Id == truckerId))
                .ToList();

            return trips;
        }

        public ICollection<Trip> Get()
        {
            return _context.Trips
                .Include(t => t.UserCreation)
                .ToList();
        }

    }
}
