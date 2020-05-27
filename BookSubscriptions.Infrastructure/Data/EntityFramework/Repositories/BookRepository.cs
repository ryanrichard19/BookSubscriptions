using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using BookSubscriptions.Core.Domain.Entities;
using BookSubscriptions.Core.Dto;
using BookSubscriptions.Core.Dto.GatewayResponses.Repositories;
using BookSubscriptions.Core.Interfaces.Gateways.Repositories;
using BookSubscriptions.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookSubscriptions.Infrastructure.Data.EntityFramework.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Book>> ListAsync()
        {
            return _dbContext.Books.ToListAsync();
        }

        public Task<Book> GetByIdAsync(int id)
        {
            return _dbContext.Books.SingleOrDefaultAsync(e => e.Id == id);
        }
    }
}