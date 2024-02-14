using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Reservation.Command.Create
{
    public class CreateReservationCommand : IRequest<ReservationDto?>
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalGuests { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid ApartmentId { get; set; }
        public Guid GuestId { get; set; }

        public CreateReservationCommand(DateTime checkInDate,
            DateTime checkOutDate, int totalGuests, decimal totalPrice,
            Guid apartmentId, Guid guestId)
        {
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            TotalGuests = totalGuests;
            TotalPrice = totalPrice;
            ApartmentId = apartmentId;
            GuestId = guestId;
        }
    }
}
