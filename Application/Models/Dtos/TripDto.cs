using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class TripDto
    {
        public int Id { get; set; }
        public string Source { get; set; } = string.Empty;
        public string Destiny { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TripStatus Status { get; set; }
        public AdminDto UserCreation { get; set; } = new AdminDto();

        public static TripDto ToDto(Trip trip)
        {
            TripDto dto = new()
            {
                Id = trip.Id,
                Source = trip.Source,
                Destiny = trip.Destiny,
                Description = trip.Description,
                Status = trip.TripStatus
            };
            dto.UserCreation = AdminDto.ToDto(trip.UserCreation);

            return dto;
        }

        public static ICollection<TripDto> ToDto(ICollection<Trip> trips)
        {
            return trips.Select(trip => ToDto(trip)).ToList();
        }
    }
}
