using ReservationApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Domain.Interfaces
{
    public interface IApartmentRepository: IGenericRepository<Apartment>
    {
        public int GetMaxGuest(Guid id);
        public decimal GetPrice(Guid id);
        public Task<bool> isExist(Guid id);
    }
}
