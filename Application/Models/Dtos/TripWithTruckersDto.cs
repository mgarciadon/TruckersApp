using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class TripWithTruckersDto
    {
        public int Id { get; set; }
        public string Source { get; set; } = string.Empty;
        public string Destiny { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<TruckerDto> Truckers { get; set; } = [];
        public AdminDto UserCreation { get; set; } = new AdminDto();

        public static TripWithTruckersDto ToDto(Trip trip)
        {
            TripWithTruckersDto dto = new()
            {
                Id = trip.Id,
                Source = trip.Source,
                Destiny = trip.Destiny,
                Description = trip.Description
            };
            foreach (Trucker trucker in trip.Truckers)
            {
                dto.Truckers.Add(TruckerDto.ToDto(trucker));
            }
            dto.UserCreation = AdminDto.ToDto(trip.UserCreation);

            return dto;
        }

        public static ICollection<TripWithTruckersDto> ToDto(ICollection<Trip> trips)
        {
            return trips.Select(trip => ToDto(trip)).ToList();
        }

        public static Trip ToEntity(TripWithTruckersDto dto)
        {
            Trip trip = new()
            {
                Id = dto.Id,
                Source = dto.Source,
                Destiny = dto.Destiny,
                Description = dto.Description
            };
            foreach (TruckerDto trucker in dto.Truckers)
            {
                trip.Truckers.Add(TruckerDto.ToEntity(trucker));
            }
            trip.UserCreation = AdminDto.ToEntity(dto.UserCreation);

            return trip;
        }
    }
}
