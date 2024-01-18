using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReservationApi.Application.ApartmentCQRS.Command.Create;
using ReservationApi.Application.ApartmentCQRS.Command.Delete;
using ReservationApi.Application.ApartmentCQRS.Command.Edit;
using ReservationApi.Application.ApartmentCQRS.Query.GetAll;
using ReservationApi.Application.ApartmentCQRS.Query.GetById;
using ReservationApi.Application.Pagination;
using ReservationApi.Domain.Entities;

namespace ReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]PaginationDto pagination)
        {
            var result =await _mediator.Send(new GetAllApartmentQuery(pagination));
            return Ok(result);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            var result = await _mediator.Send(new GetByIdApartmentQuery(Id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateApartmentCommand command)
        {

            CreateApartmentCommandValidator _validator = new CreateApartmentCommandValidator();
            ValidationResult result = await _validator.ValidateAsync(command);

            if (!result.IsValid)
                return BadRequest(command);
            var data = await _mediator.Send(command);
            if (data == null)
                return BadRequest(command);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditApartmentCommand command)
        {
            EditApartmentCommandValidator _validator = new EditApartmentCommandValidator();
            ValidationResult result = await _validator.ValidateAsync(command);

            if (!result.IsValid)
                return BadRequest(command);
            var data = await _mediator.Send(command);
            if (data == null)
                return BadRequest(command);
            return Ok(data);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteApartmentCommand(id));
            return NoContent();
        }
    }
}
