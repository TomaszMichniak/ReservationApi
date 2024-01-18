﻿using MediatR;
using ReservationApi.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.ApartmentCQRS.Query.GetById
{
    public class GetByIdApartmentQuery : IRequest<ApartmentDto>
    {
        public Guid Id { get; set; }

        public GetByIdApartmentQuery(Guid id)
        {
            Id = id;
        }
    }
}
