using Application.Models.Dtos;
using Application.Models.Requests;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        ICollection<AdminDto> GetAll();
        AdminDto Create(UserSaveRequest admin);
        void DeleteAdmin(int id);
        AdminDto GetById(int id);
        AdminDto UpdateAdmin(int id,UserSaveRequest admin);
    }
}
