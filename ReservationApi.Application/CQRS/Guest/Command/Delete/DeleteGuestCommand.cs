using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Guest.Command.Delete
{
    public class DeleteGuestCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteGuestCommand(Guid id)
        {
            Id = id;
        }
    }
}
