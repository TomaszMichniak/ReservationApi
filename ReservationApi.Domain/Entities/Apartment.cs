using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Domain.Entities
{
    public class Apartment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }= default!;
        public string Description { get; set; } = default!;
        public int MaxGuests { get; set; } = 2;
        public decimal RatePerNight { get; set; } = 100;
        public ICollection<Reservation> Reservation { get; set; } = new List<Reservation>();
    }
}
