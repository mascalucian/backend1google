using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.DTOs;
using AspNetSandbox2;
using AspNetSandbox2.Data;
using AspNetSandbox2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository repository;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

       public BooksController(IBookRepository repository, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.repository = repository;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        // GET: api/<BooksController>

        /// <summary>
        /// Gets all book objects.
        /// </summary>
        /// <returns>ReadBookDto objects.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var books = repository.GetBooks();
            var readBookDtoList = mapper.Map<IEnumerable<DTOs.ReadBookDto>>(books);
            return Ok(readBookDtoList);
        }

        // GET api/<BooksController>/5

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ReadBookDto object.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Book book = repository.GetBook(id);
                AspNetSandbox2.ReadBookDto readBookDto = mapper.Map<AspNetSandbox2.ReadBookDto>(book);
                return Ok(readBookDto);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST api/<BooksController>

        /// <summary>
        /// Adds a new Book object.
        /// </summary>
        /// <param name="bookDto">The value.</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                Book book = mapper.Map<Book>(bookDto);
                repository.AddBook(book);
                await hubContext.Clients.All.SendAsync("AddedBook", book);
                return Ok();
            } 
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<BooksController>/5

        /// <summary>
        /// Updates a Book object by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="bookDto">The value.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CreateBookDto bookDto)
        {
            Book book = mapper.Map<Book>(bookDto);
            repository.UpdateBook(id, book);
            await hubContext.Clients.All.SendAsync("EditedBook", book);
            return Ok();
        }

        // DELETE api/<BooksController>/5

        /// <summary>
        /// Deletes a Book object by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Book book = repository.GetBook(id);
            hubContext.Clients.All.SendAsync("DeletedBook", book);
            repository.DeleteBook(id);
            return Ok();
        }
    }
}