using MediatR;
using ReservationApi.Application.CQRS.AuthenticationCQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.AuthenticationCQRS.Command.Register
{

    public class CreateUserCommand : IRequest
    {
        public UserDto User { get; set; }

        public CreateUserCommand(UserDto user)
        {
            User = user;
        }

    }
}
