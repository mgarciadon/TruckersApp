using Application.Models.Dtos;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public record TripSaveRequest
    {
        public string Source { get; set; } = string.Empty;
        public string Destiny { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TripStatus Status { get; set; }
        public ICollection<int> TruckerIds { get; set; } = [];
        public int UserCreationId { get; set; }
    }
}
