using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.ApartmentCQRS.Command.Delete
{
    public class DeleteApartmentCommand:IRequest
    {
        public Guid Id {  get; set; }

        public DeleteApartmentCommand(Guid id)
        {
            Id = id;
        }
    }
}
