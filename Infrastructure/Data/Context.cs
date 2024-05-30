using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins {  get; set; }
        public DbSet<Trucker> Truckers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public Context(DbContextOptions<Context> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.UserCreation)
                .WithMany(t => t.Trips)
                .HasForeignKey("UserCreationId");

            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Truckers)
                .WithMany(t => t.Trips)
                .UsingEntity(j => j
                    .ToTable("trucker_trips")
                    .HasData(CreateTruckerTripDataSeed()));

            modelBuilder.Entity<Admin>().HasData(CreateAdminDataSeed());

            modelBuilder.Entity<Trucker>().HasData(CreateTruckerDataSeed());

            modelBuilder.Entity<Trip>().HasData(CreateTripDataSeed());

            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }

        private Admin[] CreateAdminDataSeed()
        {
            return new Admin[]
            {
            new Admin
            {
                Id = 1,
                Name = "Emiliano Falabrini",
                Email = "emiliano@mail.com",
                Password = "123456"
            },
            new Admin
            {
                Id = 2,
                Name = "Pablo Paez",
                Email = "pablo@mail.com",
                Password = "123456"
            }
            };
        }

        private Trucker[] CreateTruckerDataSeed()
        {
            return new Trucker[]
            {
            new Trucker
            {
                Id = 3,
                Name = "Mateo García",
                Email = "mateo@mail.com",
                Password = "123456"
            },
            new Trucker
            {
                Id = 4,
                Name = "Agustin Baez",
                Email = "agustin@mail.com",
                Password = "123456"
            },
            new Trucker
            {
                Id = 5,
                Name = "Gabriel Furrer",
                Email = "gabriel@mail.com",
                Password = "123456"
            }
            };
        }

        private object[] CreateTripDataSeed()
        {
            return new object[]
            {
            new 
            {
                Id = 1,
                Source = "Santa Fe",
                Destiny = "Rosario",
                Description = "Soja",
                TripStatus = TripStatus.Pending,
                UserCreationId = 1
            },
            new 
            {
                Id = 2,
                Source = "Rafaela",
                Destiny = "Rosario",
                Description = "Trigo",
                TripStatus = TripStatus.Completed,
                UserCreationId = 2
            }
            };
        }

        private object[] CreateTruckerTripDataSeed()
        {
            return new object[]
            {
            new { TruckersId = 3, TripsId = 1 },
            new { TruckersId = 4, TripsId = 1 },
            new { TruckersId = 5, TripsId = 2 }
            };
        }
    }
}
