using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public static AdminDto ToDto(Admin admin)
        {
            var dto = new AdminDto
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Email
            };

            return dto;

        }

        public static ICollection<AdminDto> ToDto(ICollection<Admin> admins)
        {
            return admins.Select(admin => ToDto(admin)).ToList();
        }

        public static Admin ToEntity(AdminDto dto)
        {
            var admin = new Admin
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email
            };

            return admin;
        }

        public static Admin ToEntity(UserSaveRequest dto)
        {
            var entity = new Admin
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };

            return entity;
        }
    }
}
