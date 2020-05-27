using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookSubscriptions.API.Models;
using BookSubscriptions.Core.Domain.Entities;
using BookSubscriptions.Core.Interfaces.Gateways.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookSubscriptions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(
           IBookRepository bookRepository,
           IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetBooks()
        {
            var books = await _bookRepository.ListAsync();
            return _mapper.Map<List<Book>, List<BookDTO>>(books);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return _mapper.Map<Book, BookDTO>(book);
        }
    }
}
