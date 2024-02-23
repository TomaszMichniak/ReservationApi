using FluentValidation;
using ReservationApi.Application.CQRS.Apartment.Command.Create;
using ReservationApi.Application.CQRS.AuthenticationCQRS.Command.Register;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Authentication.Command.Register
{
    public class CreateUserCommandHandlerValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandHandlerValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Custom((value, context) =>
                {
                    var isExist= userRepository.UniqueEmail(value);
                    if (isExist) {
                        context.AddFailure("Email", "That Email is taken");
                    }
                 });
            RuleFor(x => x.Password).MinimumLength(6);
        }
    }
}
