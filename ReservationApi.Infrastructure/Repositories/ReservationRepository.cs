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
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ReservationApiDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<bool> isExist(Guid id)
        {
            return await _dbContext.Reservations.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) != null;
        }
    }
}
