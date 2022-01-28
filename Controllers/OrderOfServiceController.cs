using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectOs.Domain.Interface;
using ProjectOs.Domain.Models;
using ProjectOs.Dto.OrderOfService;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ProjectOs.Controllers
{
    [ApiController]
    [Route("v1/OrderOfService")]
    public class OrderOfServiceController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IOrderOfServiceRepository repository;

        public OrderOfServiceController(
            IOrderOfServiceRepository repository,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        [Route("Count")]
        [AllowAnonymous]
        public async Task<IActionResult> Count()
        {
            return Ok(await this.repository.CountAsync());
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OsOutputDto))]
        public async Task<ActionResult> GetAllOS(DateTime dataOpeningOSInicial, DateTime dataOpeningOSFinal, int? page)
        {
            var orderOfService = await repository.GetAllOrderOfServiceAsync(dataOpeningOSInicial, dataOpeningOSFinal, page);
            return Ok(orderOfService);
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OsOutputDto))]
        public async Task<ActionResult> GetOneOS(Guid id)
        {
            var orderOfService = await repository.GetOneOrderOfServiceAsync(id);

            if (orderOfService == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new Result(false, HttpStatusCode.BadRequest, 1001, "Order Of Service does not exists"));
            }

            return Ok(orderOfService);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateOsDto))]
        public async Task<ActionResult> CreateOS([FromBody] CreateOsDto createOSModel)
        {
            OrderOfService orderOfService = mapper.Map<OrderOfService>(createOSModel);

            await repository.CreateOrderOfServiceAsync(orderOfService);

            return CreatedAtAction(nameof(GetOneOS), new { Id = orderOfService.Id.ToString() }, orderOfService);
        }

        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateOsDto))]
        public async Task<ActionResult> UpdateOs(Guid id, [FromBody] UpdateOsDto updateOSModel)
        {
            var orderOfServiceExisting = await repository.GetOneOrderOfServiceAsync(id);

            if (orderOfServiceExisting == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new Result(false, HttpStatusCode.BadRequest, 1001, "Order Of Service does not exists"));
            }

            OrderOfService orderOfService = mapper.Map<OrderOfService>(updateOSModel);

            await repository.UpdateOrderOfServiceAsync(orderOfService);

            return Ok(orderOfService);
        }

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteOs(Guid id)
        {
            var existingOs = await repository.GetOneOrderOfServiceAsync(id);

            if (existingOs == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new Result(false, HttpStatusCode.BadRequest, 1001, "Order Of Service does not exists"));
            }

            await repository.DeleteOrderOfServiceAsync(id);
            return NoContent();
        }
    }
}
