using Application.Models.Requests;
using Domain.Entities;
namespace Application.Models.Dtos
{
    public class TruckerDto
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public static TruckerDto ToDto(Trucker trucker)
        {
            var dto = new TruckerDto
            {
                Id = trucker.Id,
                Name = trucker.Name,
                Email = trucker.Email
            };

            return dto;

        }

        public static ICollection<TruckerDto> ToDto(ICollection<Trucker> truckers)
        {
            return truckers.Select(trucker => ToDto(trucker)).ToList();
        }

        public static Trucker ToEntity(TruckerDto dto)
        {
            var trucker = new Trucker
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email
            };

            return trucker;
        }

        public static Trucker ToEntity(UserSaveRequest trucker)
        {
            var entity = new Trucker
            {
                Name = trucker.Name,
                Email = trucker.Email,
                Password = trucker.Password
            };

            return entity;

        }

    }
}
