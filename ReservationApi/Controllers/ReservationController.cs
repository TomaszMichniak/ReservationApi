using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationApi.Application.CQRS.Apartment.Command.Create;
using ReservationApi.Application.CQRS.Guest.Query.GetBySpecification;
using ReservationApi.Application.CQRS.Reservation.Command.Create;
using ReservationApi.Application.CQRS.Reservation.Command.Delete;
using ReservationApi.Application.CQRS.Reservation.Command.Edit;
using ReservationApi.Application.CQRS.Reservation.Query.GetAll;
using ReservationApi.Application.CQRS.Reservation.Query.GetById;
using ReservationApi.Application.CQRS.Reservation.Query.GetBySpecification;
using ReservationApi.Application.Pagination;
using ReservationApi.Domain.Interfaces;
using ReservationApi.Infrastructure.Database;
using ReservationApi.Infrastructure.Repositories;

namespace ReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IApartmentRepository _apartmentRepository;

        public ReservationController(IMediator mediator, IApartmentRepository apartmentRepository)
        {
            _mediator = mediator;
            _apartmentRepository = apartmentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationDto paginationDto)
        {
            var result = await _mediator.Send(new GetAllReservationQuery(paginationDto));
            return Ok(result);
        }
        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> GetBySpecification([FromQuery] GetBySpecificationReservationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            var result = await _mediator.Send(new GetByIdReservationQuery(Id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservationCommand command)
        {
            CreateReservationCommandValidator _validator = new CreateReservationCommandValidator(_apartmentRepository);
            ValidationResult result = await _validator.ValidateAsync(command);

            if (!result.IsValid)
                return BadRequest(command);
            var data = await _mediator.Send(command);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditReservationCommand command)
        {
            EditReservationCommandValidator _validator = new EditReservationCommandValidator(_apartmentRepository);
            ValidationResult result = await _validator.ValidateAsync(command);

            if (!result.IsValid)
                return BadRequest(command);
            var data = await _mediator.Send(command);
            return Ok(data);
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            await _mediator.Send(new DeleteReservationCommand(Id));
            return NoContent();
        }
    }
}
