using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public AdminDto Create(UserSaveRequest admin)
        {
            var entity = AdminDto.ToEntity(admin);

            _adminRepository.AddAsync(entity).Wait();
            _adminRepository.SaveChangesAsync().Wait();
            return AdminDto.ToDto(entity);
        }

        public AdminDto UpdateAdmin(int id,UserSaveRequest admin)
        {
            var adminToUpdate = _adminRepository.GetByIdAsync(id).Result
                ?? throw new Exception("Fatal error");

            adminToUpdate.Name = admin.Name;
            adminToUpdate.Email = admin.Email;
            adminToUpdate.Password = admin.Password;

            _adminRepository.UpdateAsync(adminToUpdate).Wait();
            _adminRepository.SaveChangesAsync().Wait();
            return AdminDto.ToDto(adminToUpdate);
        }

        public void DeleteAdmin(int id)
        {
            _adminRepository.DeleteAsync(GetAdminById(id)).Wait();
            _adminRepository.SaveChangesAsync().Wait();
        }

        public ICollection<AdminDto> GetAll()
        {
            return AdminDto.ToDto(_adminRepository.ListAsync().Result);
        }

        public AdminDto GetById(int id)
        {
            return AdminDto.ToDto(GetAdminById(id));
        }

        private Admin GetAdminById(int id)
        {
            return _adminRepository.GetByIdAsync(id).Result ?? throw new Exception("User not found");
        }
    }
}
