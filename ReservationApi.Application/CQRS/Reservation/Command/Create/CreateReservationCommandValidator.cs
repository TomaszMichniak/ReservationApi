using FluentValidation;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Reservation.Command.Create
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        private readonly IApartmentRepository _apartmentRepository;

        public CreateReservationCommandValidator(IApartmentRepository apartmentRepository)
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
