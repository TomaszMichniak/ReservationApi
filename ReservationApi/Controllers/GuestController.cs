using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationApi.Application.CQRS.Apartment.Query.GetAll;
using ReservationApi.Application.CQRS.Guest.Query.GetAll;
using ReservationApi.Application.Pagination;

namespace ReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GuestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]PaginationDto pagination)
        {
            var result = await _mediator.Send(new GetAllGuestQuery(pagination));
            return Ok(result);
        }
    }
}
