using System;
using AirTiquicia.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirTiquicia.Infrastructure.Data
{
    public partial class AirTiquiciaContext : DbContext
    {
        public AirTiquiciaContext()
        {
        }

        public AirTiquiciaContext(DbContextOptions<AirTiquiciaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aeroline> Aeroline { get; set; }
        public virtual DbSet<Airplane> Airplane { get; set; }
        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Crew> Crew { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Luggage> Luggage { get; set; }
        public virtual DbSet<Passenger> Passenger { get; set; }
        public virtual DbSet<Seat> Seat { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aeroline>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Airplane>(entity =>
            {
                entity.HasKey(e => e.IdAirplane);

                entity.Property(e => e.IdAirplane).HasMaxLength(50);

                entity.HasOne(d => d.IdAerolineNavigation)
                    .WithMany(p => p.Airplane)
                    .HasForeignKey(d => d.IdAeroline)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Airplane_Aeroline");
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(e => e.IdAirport);

                entity.Property(e => e.IdAirport).HasMaxLength(50);

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Airport)
                    .HasForeignKey(d => d.IdCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Airport_Country");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Crew>(entity =>
            {
                entity.Property(e => e.IdEmployee)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Crew)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Crew_Employee");

                entity.HasOne(d => d.IdFlightNavigation)
                    .WithMany(p => p.Crew)
                    .HasForeignKey(d => d.IdFlight)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Crew_Flight");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);

                entity.Property(e => e.IdEmployee).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.Property(e => e.ArrivalDate).HasColumnType("datetime");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DepartureAirport)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DepartureDate).HasColumnType("datetime");

                entity.Property(e => e.DestinationAirport)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdAirplane)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Stopover).HasMaxLength(50);

                entity.HasOne(d => d.DepartureAirportNavigation)
                    .WithMany(p => p.FlightDepartureAirportNavigation)
                    .HasForeignKey(d => d.DepartureAirport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flight_DepartureAirport");

                entity.HasOne(d => d.DestinationAirportNavigation)
                    .WithMany(p => p.FlightDestinationAirportNavigation)
                    .HasForeignKey(d => d.DestinationAirport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flight_DestinationAirport");

                entity.HasOne(d => d.IdAirplaneNavigation)
                    .WithMany(p => p.Flight)
                    .HasForeignKey(d => d.IdAirplane)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flight_Airplane");

                entity.HasOne(d => d.StopoverNavigation)
                    .WithMany(p => p.FlightStopoverNavigation)
                    .HasForeignKey(d => d.Stopover)
                    .HasConstraintName("FK_Flight_StopoverAirport");
            });

            modelBuilder.Entity<Luggage>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("decimal(12, 2)");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Birthdate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.Seat)
                    .HasForeignKey(d => d.IdClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seat_Class");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IdPassenger)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(12, 2)");

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.IdClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Class");

                entity.HasOne(d => d.IdFlightNavigation)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.IdFlight)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Flight");

                entity.HasOne(d => d.IdLuggageNavigation)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.IdLuggage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Luggage");

                entity.HasOne(d => d.IdPassengerNavigation)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.IdPassenger)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Passenger");
            });
        }
    }
}
