using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationApi.Application.CQRS.Apartment.Command.Create;
using ReservationApi.Application.CQRS.Reservation.Command.Create;
using ReservationApi.Application.CQRS.Reservation.Command.Delete;
using ReservationApi.Application.CQRS.Reservation.Query.GetAll;
using ReservationApi.Application.CQRS.Reservation.Query.GetById;
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
            if (data == null)
                return BadRequest(command);
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
