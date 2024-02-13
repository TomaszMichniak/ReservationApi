using ReservationApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Domain.Interfaces
{
    public interface IGuestRepository : IGenericRepository<Guest>
    {
        public Task<bool> isExist(Guid id);
    }
}
