using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class TruckerService : ITruckerService
    {
        private readonly ITruckerRepository _truckerRepository;
        public TruckerService(ITruckerRepository truckerRepository)
        { 
            _truckerRepository = truckerRepository;
        }

        public TruckerDto Create(UserSaveRequest trucker)
        {
            var entity = TruckerDto.ToEntity(trucker);
            _truckerRepository.AddAsync(entity).Wait();
            _truckerRepository.SaveChangesAsync().Wait();

            return TruckerDto.ToDto(entity);

        }

        public TruckerDto Update(int id,UserSaveRequest trucker)
        {
            var truckerToUpdate = _truckerRepository.GetByIdAsync(id).Result
                ?? throw new Exception("Fatal error");

            truckerToUpdate.Name = trucker.Name;
            truckerToUpdate.Email = trucker.Email;
            truckerToUpdate.Password = trucker.Password;

            _truckerRepository.UpdateAsync(truckerToUpdate).Wait();
            _truckerRepository.SaveChangesAsync().Wait();

            return TruckerDto.ToDto(truckerToUpdate);
        }

        public void Delete(int id)
        {
            var entity = GetTrucker(id);
            _truckerRepository.DeleteAsync(entity).Wait();
            _truckerRepository.SaveChangesAsync().Wait();
        }

        public ICollection<TruckerDto> GetAll()
        {
            return TruckerDto.ToDto(_truckerRepository.ListAsync().Result);
        }

        public TruckerDto GetById(int id)
        {
            var entity = GetTrucker(id);
            return TruckerDto.ToDto(entity);
        }

        private Trucker GetTrucker(int id)
        {
           return _truckerRepository.GetByIdAsync(id).Result ?? throw new Exception("User not found");
        }

    }
}
