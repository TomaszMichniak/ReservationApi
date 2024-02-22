using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationApi.Application.CQRS.Apartment.Query.GetAll;
using ReservationApi.Application.CQRS.Apartment.Query.GetBySpecification;
using ReservationApi.Application.CQRS.Guest.Command.Create;
using ReservationApi.Application.CQRS.Guest.Command.Delete;
using ReservationApi.Application.CQRS.Guest.Command.Edit;
using ReservationApi.Application.CQRS.Guest.Query.GetAll;
using ReservationApi.Application.CQRS.Guest.Query.GetById;
using ReservationApi.Application.CQRS.Guest.Query.GetBySpecification;
using ReservationApi.Application.Pagination;

namespace ReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<GuestController> _logger;

        public GuestController(IMediator mediator, ILogger<GuestController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationDto pagination)
        {
            var result = await _mediator.Send(new GetAllGuestQuery(pagination));
            return Ok(result);
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            _logger.LogTrace("asasasa");
            var result = await _mediator.Send(new GetByIdGuestQuery(Id));
            return Ok(result);
        }
        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> GetBySpecification([FromQuery] GetBySpecificationGuestQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        //[Authorize(Roles ="admin")]

        public async Task<IActionResult> Create([FromBody] CreateGuestCommand command)
        {
            CreateGuestCommandValidator _validator = new CreateGuestCommandValidator();
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
        //[Authorize(Roles ="admin")]

        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            await _mediator.Send(new DeleteGuestCommand(Id));
            return NoContent();
        }
        [HttpPut]
        //[Authorize(Roles ="admin")]
        public async Task<IActionResult> Edit([FromBody] EditGuestCommand command)
        {
            EditGuestCommandValidator _validator = new EditGuestCommandValidator();
            ValidationResult result = await _validator.ValidateAsync(command);

            if (!result.IsValid)
                return BadRequest(command);
            var data = await _mediator.Send(command);
        
            return Ok(data);
            
        }
    }
}
