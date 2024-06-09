using AutoMapper;
using bookStore.CustomeActionFilter;
using bookStore.Models.Domain;
using bookStore.Models.Dto;
using bookStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemRepository orderItemRepository;
        private readonly IMapper mapper;

        public OrderItemController(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            this.orderItemRepository = orderItemRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderItemsDomain = await orderItemRepository.GetAllAsync();
            var orderItemsDto = mapper.Map<List<OrderItemDto>>(orderItemsDomain);
            return Ok(orderItemsDto);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var orderItemDomain = await orderItemRepository.GetByIdAsync(id);
            if (orderItemDomain == null)
            {
                return NotFound();
            }
            var orderItemDto = mapper.Map<OrderItemDto>(orderItemDomain);
            return Ok(orderItemDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Add(OrderItemCreateDto orderItemCreateDto)
        {
            var orderItemDomain = mapper.Map<OrderItem>(orderItemCreateDto);
            await orderItemRepository.AddAsync(orderItemDomain);
            var orderItemDto = mapper.Map<OrderItemDto>(orderItemDomain);
            return CreatedAtAction(nameof(GetById), new { id = orderItemDto.Id }, orderItemDto);
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update(Guid id, OrderItemUpdateDto orderItemUpdateDto)
        {
            var orderItemDomain = mapper.Map<OrderItem>(orderItemUpdateDto);
            var updatedOrderItem = await orderItemRepository.UpdateAsync(id, orderItemDomain);
            if (updatedOrderItem == null)
            {
                return NotFound();
            }
            var orderItemDto = mapper.Map<OrderItemDto>(updatedOrderItem);
            return Ok(orderItemDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedOrderItem = await orderItemRepository.DeleteAsync(id);
            if (deletedOrderItem == null)
            {
                return NotFound();
            }
            var orderItemDto = mapper.Map<OrderItemDto>(deletedOrderItem);
            return Ok(orderItemDto);
        }
    }
}
