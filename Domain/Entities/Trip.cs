using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities
{
    public class Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Source { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Destiny { get; set; }

        [MaxLength(50)]
        public string? Description { get; set; }

        public ICollection<Trucker>? Truckers { get; set; }

        public Admin UserCreation { get; set; } = new Admin();

        public TripStatus TripStatus { get; set; }

    }
}