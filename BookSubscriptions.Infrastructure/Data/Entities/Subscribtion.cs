using System;
using BookSubscriptions.Core.Domain.Entities;

namespace BookSubscriptions.Infrastructure.Data.Entities
{
    public class Subscribtion : EntityFramework.Entities.BaseEntity
    {
        public AppUser AppUser { get; set; }
        public Book Book { get; set; }
    }
}
