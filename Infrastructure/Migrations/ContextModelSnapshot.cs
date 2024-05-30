﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("Domain.Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Destiny")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("TripStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserCreationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserCreationId");

                    b.ToTable("Trips");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Soja",
                            Destiny = "Rosario",
                            Source = "Santa Fe",
                            TripStatus = 0,
                            UserCreationId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Trigo",
                            Destiny = "Rosario",
                            Source = "Rafaela",
                            TripStatus = 2,
                            UserCreationId = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TripTrucker", b =>
                {
                    b.Property<int>("TripsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TruckersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TripsId", "TruckersId");

                    b.HasIndex("TruckersId");

                    b.ToTable("trucker_trips", (string)null);

                    b.HasData(
                        new
                        {
                            TripsId = 1,
                            TruckersId = 3
                        },
                        new
                        {
                            TripsId = 1,
                            TruckersId = 4
                        },
                        new
                        {
                            TripsId = 2,
                            TruckersId = 5
                        });
                });

            modelBuilder.Entity("Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "emiliano@mail.com",
                            Name = "Emiliano Falabrini",
                            Password = "123456"
                        },
                        new
                        {
                            Id = 2,
                            Email = "pablo@mail.com",
                            Name = "Pablo Paez",
                            Password = "123456"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Trucker", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.HasDiscriminator().HasValue("Trucker");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Email = "mateo@mail.com",
                            Name = "Mateo García",
                            Password = "123456"
                        },
                        new
                        {
                            Id = 4,
                            Email = "agustin@mail.com",
                            Name = "Agustin Baez",
                            Password = "123456"
                        },
                        new
                        {
                            Id = 5,
                            Email = "gabriel@mail.com",
                            Name = "Gabriel Furrer",
                            Password = "123456"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Trip", b =>
                {
                    b.HasOne("Domain.Entities.Admin", "UserCreation")
                        .WithMany("Trips")
                        .HasForeignKey("UserCreationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserCreation");
                });

            modelBuilder.Entity("TripTrucker", b =>
                {
                    b.HasOne("Domain.Entities.Trip", null)
                        .WithMany()
                        .HasForeignKey("TripsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Trucker", null)
                        .WithMany()
                        .HasForeignKey("TruckersId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Admin", b =>
                {
                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
