using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservationApi.Application.CQRS.Apartment.Command.Create;
using ReservationApi.Application.CQRS.Apartment.Command.Delete;
using ReservationApi.Application.CQRS.Apartment.Command.Edit;
using ReservationApi.Application.CQRS.Apartment.Query.GetAll;
using ReservationApi.Application.CQRS.Apartment.Query.GetById;
using ReservationApi.Application.CQRS.Apartment.Query.GetBySpecification;
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
        [Route("Search")]
        public async Task<IActionResult> GetBySpecification([FromQuery]GetBySpecificationApartmentQuery query )
        {
            var result=await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetByIdApartmentQuery(id));
            return Ok(result);
        }
        [HttpPost]
       // [Authorize(Roles ="admin")]
        public async Task<IActionResult> Create([FromBody] CreateApartmentCommand command)
        {

            CreateApartmentCommandValidator _validator = new CreateApartmentCommandValidator();
            ValidationResult result = await _validator.ValidateAsync(command);

            if (!result.IsValid)
                return BadRequest(command);
            var data = await _mediator.Send(command);
            
            return Ok(data);
        }
        [HttpPut]
       //[Authorize(Roles ="admin")]
        public async Task<IActionResult> Edit([FromBody] EditApartmentCommand command)
        {
            EditApartmentCommandValidator _validator = new EditApartmentCommandValidator();
            ValidationResult result = await _validator.ValidateAsync(command);
            if (!result.IsValid)
                return BadRequest(command);
            var data = await _mediator.Send(command);
      
            return Ok(data);
        }
        [HttpDelete]
        [Route("{id}")]
       // [Authorize(Roles ="admin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteApartmentCommand(id));
            return NoContent();
        }
    }
}
