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
    public class BookController
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

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
    {
        var books = await _bookRepository.ListAsync();
        return _mapper.Map<List<Book>, List<BookDTO>>(books);
    }
}
}
