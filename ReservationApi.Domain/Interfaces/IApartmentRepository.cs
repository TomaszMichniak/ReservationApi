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
        public Task<Apartment?> UpdateApartment(Apartment apartment);
    }
}
