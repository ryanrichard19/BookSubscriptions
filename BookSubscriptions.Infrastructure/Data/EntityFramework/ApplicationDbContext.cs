using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookSubscriptions.Core.Domain.Entities;

namespace BookSubscriptions.Infrastructure.Data.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasIndex(a => a.UserName)
                .IsUnique();

            // Many-to-many: AppUser <-> Book
            modelBuilder.Entity<Subscribtion>()
                .HasKey(ca => new { ca.AppUserId, ca.BookId });



        }

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Subscribtion> Subscribtion { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }


        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is Entities.BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((Entities.BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
                ((Entities.BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}
