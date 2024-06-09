using AutoMapper;
using bookStore.CustomeActionFilter;
using bookStore.Models.Domain;
using bookStore.Models.Dto;
using bookStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository publisherRepository;
        private readonly IMapper mapper;

        public PublisherController(IPublisherRepository publisherRepository, IMapper mapper)
        {
            this.publisherRepository = publisherRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var publishersDomain = await publisherRepository.GetAllAsync();
            var publishersDto = mapper.Map<List<PublisherDto>>(publishersDomain);
            return Ok(publishersDto);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var publisherDomain = await publisherRepository.GetByIdAsync(id);
            if (publisherDomain == null)
            {
                return NotFound();
            }
            var publisherDto = mapper.Map<PublisherDto>(publisherDomain);
            return Ok(publisherDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Add(PublisherCreateDto publisherCreateDto)
        {
            var publisherDomain = mapper.Map<Publisher>(publisherCreateDto);
            await publisherRepository.AddAsync(publisherDomain);
            var publisherDto = mapper.Map<PublisherDto>(publisherDomain);
            return CreatedAtAction(nameof(GetById), new { id = publisherDto.Id }, publisherDto);
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update(Guid id, PublisherUpdateDto publisherUpdateDto)
        {
            var publisherDomain = mapper.Map<Publisher>(publisherUpdateDto);
            var updatedPublisher = await publisherRepository.UpdateAsync(id, publisherDomain);
            if (updatedPublisher == null)
            {
                return NotFound();
            }
            var publisherDto = mapper.Map<PublisherDto>(updatedPublisher);
            return Ok(publisherDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedPublisher = await publisherRepository.DeleteAsync(id);
            if (deletedPublisher == null)
            {
                return NotFound();
            }
            var publisherDto = mapper.Map<PublisherDto>(deletedPublisher);
            return Ok(publisherDto);
        }
    }
}
