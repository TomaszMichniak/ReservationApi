using FluentValidation;
using ReservationApi.Application.CQRS.Reservation.Command.Create;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Reservation.Command.Edit
{
    public class EditReservationCommandValidator:AbstractValidator<EditReservationCommand>
    {
        private readonly IApartmentRepository _apartmentRepository;

        public EditReservationCommandValidator(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
            RuleFor(x => x.TotalGuests).Must((reservation, totalGuest) =>
            {
                int maxGuest = _apartmentRepository.GetMaxGuest(reservation.ApartmentId);
                return totalGuest <= maxGuest && totalGuest > 0;
            }).WithMessage("TotalGuest must be lower or equal than apartment maximum guest");
        }
    }
}
