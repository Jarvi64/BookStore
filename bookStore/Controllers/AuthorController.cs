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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authorsDomain = await authorRepository.GetAllAsync();
            var authorsDto = mapper.Map<List<AuthorDto>>(authorsDomain);
            return Ok(authorsDto);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var authorDomain = await authorRepository.GetByIdAsync(id);
            if (authorDomain == null)
            {
                return NotFound();
            }
            var authorDto = mapper.Map<AuthorDto>(authorDomain);
            return Ok(authorDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Add(AuthorCreateDto authorCreateDto)
        {
            var authorDomain = mapper.Map<Author>(authorCreateDto);
            await authorRepository.AddAsync(authorDomain);
            var authorDto = mapper.Map<AuthorDto>(authorDomain);
            return CreatedAtAction(nameof(GetById), new { id = authorDto.Id }, authorDto);
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update(Guid id, AuthorUpdateDto authorUpdateDto)
        {
            var authorDomain = mapper.Map<Author>(authorUpdateDto);
            var updatedAuthor = await authorRepository.UpdateAsync(id, authorDomain);
            if (updatedAuthor == null)
            {
                return NotFound();
            }
            var authorDto = mapper.Map<AuthorDto>(updatedAuthor);
            return Ok(authorDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedAuthor = await authorRepository.DeleteAsync(id);
            if (deletedAuthor == null)
            {
                return NotFound();
            }
            var authorDto = mapper.Map<AuthorDto>(deletedAuthor);
            return Ok(authorDto);
        }
    }
}
