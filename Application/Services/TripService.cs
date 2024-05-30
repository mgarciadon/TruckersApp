using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

namespace Application.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly ITruckerRepository _truckerRepository;
        public TripService (ITripRepository tripRepository, IAdminRepository adminRepository, ITruckerRepository truckerRepository)
        {
            _tripRepository = tripRepository;
            _adminRepository = adminRepository;
            _truckerRepository = truckerRepository;
        }

        public TripWithTruckersDto Create(TripSaveRequest trip)
        {
            var entity = new Trip();
            entity.Truckers = [];
            foreach(int id in trip.TruckerIds) {
                var trucker = _truckerRepository.GetByIdAsync(id).Result;
                entity.Truckers.Add(trucker);
                
            }

            entity.Source = trip.Source;
            entity.Destiny = trip.Destiny;
            entity.TripStatus = trip.Status;
            entity.UserCreation = _adminRepository.GetByIdAsync(trip.UserCreationId).Result;

            _tripRepository.AddAsync(entity).Wait();
            _tripRepository.SaveChangesAsync().Wait();

            return TripWithTruckersDto.ToDto(entity);
        }

        

        public ICollection<TripWithTruckersDto> GetByStatus(TripStatus status)
        {
            var entity = _tripRepository.GetByStatus(status);
           
            return TripWithTruckersDto.ToDto(entity);
        }

        public ICollection<TripDto> GetByTruckerId(int truckerId)
        {
            var entity = _tripRepository.GetByTruckerId(truckerId);

            return TripDto.ToDto(entity);
        }

        public ICollection<TripDto> Get()
        {
            var list = _tripRepository.Get();
                
            return TripDto.ToDto(list);
        }

    }
}
