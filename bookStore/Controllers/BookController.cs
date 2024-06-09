using AutoMapper;
using bookStore.CustomeActionFilter;
using bookStore.Data;
using bookStore.Models.Domain;
using bookStore.Models.Dto;
using bookStore.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BookController(IBookRepository bookRepository,IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var booksDomain = await bookRepository.GetAllAsync();
            var booksDto = mapper.Map<List<BookDto>>(booksDomain);
            return Ok(booksDto);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var bookDomain = await bookRepository.GetByIdAsync(id);
            if (bookDomain == null)
            {
                return NotFound();
            }
            var bookDto = mapper.Map<BookDto>(bookDomain);
            return Ok(bookDto);
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Add(BookCreateDto bookCreateDto)
        {
            var bookDomain = mapper.Map<Book>(bookCreateDto);
            await bookRepository.AddAsync(bookDomain);
            var bookDto = mapper.Map<BookDto>(bookDomain);
            return CreatedAtAction(nameof(GetById), new { id = bookDto.Id }, bookDto);
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update(Guid id, BookUpdateDto bookUpdateDto)
        {
            var bookDomain = mapper.Map<Book>(bookUpdateDto);
            bookDomain = await bookRepository.UpdateAsync(id, bookDomain);
            if (bookDomain == null) { 
                return NotFound();
            }
            var bookDto = mapper.Map<BookDto>(bookDomain);
            return Ok(bookDomain);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await bookRepository.DeleteAsync(id);
            return Ok(book);
        }
    }
}
