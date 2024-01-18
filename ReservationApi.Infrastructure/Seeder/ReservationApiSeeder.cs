using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReservationApi.Domain.Entities;
using ReservationApi.Infrastructure.Database;

namespace ReservationApi.Infrastructure.Seeder
{
    public class ReservationApiSeeder
    {
        private readonly ReservationApiDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public ReservationApiSeeder(ReservationApiDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
        public async Task Seed()
        {

            if (!_dbContext.Apartaments.Any())
            {
                var apartments = GetApartments();
                _dbContext.Apartaments.AddRange(apartments);
                await _dbContext.SaveChangesAsync();
            }
            if (!_dbContext.Roles.Any())
            {
                var role = GetRoles();
                _dbContext.Roles.AddRange(role);
                await _dbContext.SaveChangesAsync();
            }
            if (!_dbContext.Users.Any())
            {
                _dbContext.Users.AddRange(GetUsers());
                await _dbContext.SaveChangesAsync();
            }
        }
        private IEnumerable<Apartment> GetApartments()
        {
            var apartments=new List<Apartment>()
            {
                new Apartment()
                {
                    Name="Rzeczne zacisze",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus hendrerit tellus eu dolor commodo, id tristique elit scelerisque. Praesent suscipit enim sed rhoncus mattis.",
                    MaxGuests=8,
                    RatePerNight=80,
                },
                new Apartment()
                {
                    Name="Górski Zątek",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus hendrerit tellus eu dolor commodo, id tristique elit scelerisque. Praesent suscipit enim sed rhoncus mattis.",
                    MaxGuests=4,
                    RatePerNight=90,
                }

            };
            return apartments;
        }
        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    FirstName="admin",
                    LastName="admin",
                    Phone="111222333",
                    Email="admin@admin.com",
                    RoleId=1,
                },
                new User()
                {
                    FirstName="Adam",
                    LastName="Nowak",
                    Phone="999888777",
                    Email="Adam@gmail.com"
                }
            };
            users[0].PasswordHash = _passwordHasher.HashPassword(users[0], "string");
            users[1].PasswordHash = _passwordHasher.HashPassword(users[1], "string");
            return users;
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "admin",
                },
                new Role()
                {
                    Name = "user",
                }
            };
            return roles;
        }
    }
}
