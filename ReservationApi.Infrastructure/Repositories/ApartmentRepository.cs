using Microsoft.EntityFrameworkCore;
using ReservationApi.Domain.Entities;
using ReservationApi.Domain.Interfaces;
using ReservationApi.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Infrastructure.Repositories
{
    public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(ReservationApiDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<bool> isExist(Guid id)
        {
            return await _dbContext.Apartaments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) != null;
        }
        public async Task<Apartment?> UpdateApartment(Apartment apartment)
        {
            if (await isExist(apartment.Id))
            {
                _dbContext.Apartaments.Update(apartment);
                await _dbContext.SaveChangesAsync();
                return apartment;
            }
            else
            {
                return null;
            }
        }
        public decimal GetPrice(Guid id)
        {
            var apartment = _dbContext.Apartaments.Find(id);
            if (apartment != null)
            {
                return apartment.RatePerNight;
            }
            return -1;
        }
        public int GetMaxGuest(Guid id)
        {

            var apartment = _dbContext.Apartaments.Find(id);
            if (apartment != null)
            {
                return apartment.MaxGuests;
            }
            return -1;
        }
    }
}
