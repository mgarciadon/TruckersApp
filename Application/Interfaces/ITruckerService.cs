using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface ITruckerService
    {
        TruckerDto Create(UserSaveRequest trucker);
        TruckerDto Update(int id,UserSaveRequest trucker);
        void Delete(int id);
        ICollection<TruckerDto> GetAll();
        TruckerDto GetById(int id);
    }
}
