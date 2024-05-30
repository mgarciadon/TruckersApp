using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface ITripService
    {
        TripWithTruckersDto Create(TripSaveRequest trip);
        ICollection<TripWithTruckersDto> GetByStatus(TripStatus status);
        ICollection<TripDto> GetByTruckerId(int truckerId);

        ICollection<TripDto> Get();
    }
}
