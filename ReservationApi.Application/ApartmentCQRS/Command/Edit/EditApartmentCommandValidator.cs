using FluentValidation;
using ReservationApi.Application.ApartmentCQRS.Command.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.ApartmentCQRS.Command.Edit
{
    public class EditApartmentCommandValidator : AbstractValidator<EditApartmentCommand>
    {
        public EditApartmentCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.MaxGuests).NotNull().GreaterThan(0);
            RuleFor(x => x.RatePerNight).NotNull().GreaterThan(0);
            RuleFor(x => x.Name).NotNull().MinimumLength(3);
            RuleFor(x => x.Description).NotNull().MinimumLength(5);
        }
    }
}
