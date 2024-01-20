using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.AuthenticationCQRS.Command.Register
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
