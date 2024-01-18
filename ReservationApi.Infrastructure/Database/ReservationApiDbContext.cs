using Microsoft.EntityFrameworkCore;
using ReservationApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Infrastructure.Database
{
    public class ReservationApiDbContext : DbContext
    {
        public DbSet<Apartment> Apartaments { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=ReservationApi;TrustServerCertificate=true;Integrated Security=true"
            );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>().Property(x => x.RatePerNight).HasPrecision(6,2);
            modelBuilder.Entity<Reservation>().Property(x => x.TotalPrice).HasPrecision(7,2);
            base.OnModelCreating(modelBuilder);

        }
    }
}
