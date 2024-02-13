using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Reservation
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime ReservationDate { get; set; }
        public int TotalGuests { get; set; }
        public decimal TotalPrice { get; set; } = 0;
        public Guid ApartmentId { get; set; }
        public Guid GuestId { get; set; }
    }
}
