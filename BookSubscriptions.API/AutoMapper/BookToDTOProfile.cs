using System;
using AutoMapper;
using BookSubscriptions.API.Models;
using BookSubscriptions.Core.Domain.Entities;

namespace BookSubscriptions.API.AutoMapper
{
    public class BookToDTOProfile : Profile
    {

        public BookToDTOProfile()
        {
            CreateMap<Book, BookDTO>();
        }
    }
}
