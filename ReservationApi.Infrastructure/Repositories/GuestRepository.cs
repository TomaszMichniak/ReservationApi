﻿using Microsoft.EntityFrameworkCore;
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
    public class GuestRepository : GenericRepository<Guest>, IGuestRepository
    {
        public GuestRepository(ReservationApiDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<bool> isExist(Guid id)
        {
            return await _dbContext.Guests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) != null;
        }
    }
}
