using Microsoft.EntityFrameworkCore;
using OWT6BA_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT6BA_HFT_2022232.Repository.Database
{
    public class BookDbContext : DbContext
    {
        // members - tables
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        // ctor
        public BookDbContext()
        {
            Database.EnsureCreated();
        }

        // method overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("BookDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // define the connections between the tables using LazyLodaing
            modelBuilder.Entity<Book>(entity =>
            {
                entity
                .HasOne(book => book.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Book>(enitiy =>
            {
                enitiy
                .HasOne(book => book.Category)
                .WithMany(category => category.Books)
                .HasForeignKey(book => book.CaregoryId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
