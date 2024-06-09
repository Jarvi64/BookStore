using AutoMapper;
using bookStore.CustomeActionFilter;
using bookStore.Models.Domain;
using bookStore.Models.Dto;
using bookStore.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ordersDomain = await orderRepository.GetAllAsync();
            var ordersDto = mapper.Map<List<OrderDto>>(ordersDomain);
            return Ok(ordersDto);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var orderDomain = await orderRepository.GetByIdAsync(id);
            if (orderDomain == null)
            {
                return NotFound();
            }
            var orderDto = mapper.Map<OrderDto>(orderDomain);
            return Ok(orderDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Add(OrderCreateDto orderCreateDto)
        {
            var orderDomain = mapper.Map<Order>(orderCreateDto);
            await orderRepository.AddAsync(orderDomain);
            var orderDto = mapper.Map<OrderDto>(orderDomain);
            return CreatedAtAction(nameof(GetById), new { id = orderDto.Id }, orderDto);
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update(Guid id, OrderUpdateDto orderUpdateDto)
        {
            var orderDomain = mapper.Map<Order>(orderUpdateDto);
            var updatedOrder = await orderRepository.UpdateAsync(id, orderDomain);
            if (updatedOrder == null)
            {
                return NotFound();
            }
            var orderDto = mapper.Map<OrderDto>(updatedOrder);
            return Ok(orderDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedOrder = await orderRepository.DeleteAsync(id);
            if (deletedOrder == null)
            {
                return NotFound();
            }
            var orderDto = mapper.Map<OrderDto>(deletedOrder);
            return Ok(orderDto);
        }
    }
}
