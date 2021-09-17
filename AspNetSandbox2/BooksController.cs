using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetSandbox;
using AspNetSandbox2.Data;
using AspNetSandbox2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace AspNetSandbox2
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly Mapper mapper;
        private readonly IBookRepository repository;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly ApplicationDbContext _context;

        public BooksController(IBookRepository repository, IHubContext<MessageHub> hubContext)
        {
            this.repository = repository;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bookList = repository.GetBooks();
            var readBookList = mapper.Map<IEnumerable<ReadBookDto>>(bookList);
            return Ok(readBookList);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
             _context.Update(book);
             _context.SaveChangesAsync();
             return Ok();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var book = repository.GetBooks(id);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        // POST api/<BooksController>
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (ModelState.IsValid)
            {
                repository.AddBook(book);
                hubContext.Clients.All.SendAsync("BookCreated", book);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            repository.DeleteBook(repository.GetBooks(id).Id);
            return Ok();
        }
    }
}
