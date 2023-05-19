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
            if (!optionsBuilder.IsConfigured)
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


            // Db seeds
            // source: https://www.kaggle.com/datasets/preethievelyn/amazon-top-100-bestsellers-in-books?select=Amazon_Bestseller_books.csv
            // Filtered dataset examples

            // categories seeds
            var categories = new List<Category>()
            {
                new Category("1*Action & Adventure"),
                new Category("2*Film & Photography"),
                new Category("3*Internet & Digital Media"),
                new Category("4*Health"),
                new Category("5*Historical Fiction"),
                new Category("6*History"),
                new Category("7*Literature & Fiction"),
                new Category("8*Maps & Atlases"),
                new Category("9*Politics"),
                new Category("10*Romance"),
                new Category("11*Society & Social Sciences"),
                new Category("12*Travel"),
            };

            // authors seeds
            var authors = new List<Author>()
            {
                new Author("1*Adam Grant"),
                new Author("2*Barack Obama"),
                new Author("3*Ben Lynch"),
                new Author("4*Bill Gates"),
                new Author("5*Carl Zimmer"),
                new Author("6*Charles Darwin"),
                new Author("7*Charles Dikens"),
                new Author("8*Dean Koontz"),
                new Author("9*Franz Kafka"),
                new Author("10*George Orwell"),
                new Author("11*George R.R. Martin"),
                new Author("12*J.K. Rowling"),
                new Author("13*Julia Quinn"),
                new Author("14*Nelson Mandela"),
                new Author("15*Oscar Wilde"),
                new Author("16*Robert T Kiyosaki"),
                new Author("17*Terry O'Brien"),
                new Author("18*Tim Marshall"),
            };

            // books seeds
            var books = new List<Book>()
            {
	            //new Book("Id*Title*ReleaseYear*Pages*Price*Rating*NumberOfReviews*AuthorId*CategoryId"),

	            new Book("1*1984*1949*328*79*4.5*61318*10*11"),
                new Book("2*50 Greatest Short Stories*2015*600*203.3*4.3*578*17*7"),
                new Book("3*A Clash of Kings*1998*761*369*4.5*11191*11*1"),
                new Book("4*A Game of Thrones*1996*694*449*4.5*2188*11*1"),
                new Book("5*A Promised Land*2020*768*184*4.7*1217*2*9"),
                new Book("6*A Tale of Two Cities*1859*304*159*4.5*4721*7*5"),
                new Book("7*An Offer From a Gentleman: Bridgerton*2001*358*294.04*4.6*17090*13*5"),
                new Book("8*Animal Farm*1945*112*99*4.6*33951*10*7"),
                new Book("9*Bridgerton: The Duke and I*2000*339*399*4.5*30616*13*1"),
                new Book("10*Dirty Genes: A Breakthrough Program to Treat the Root Cause of Illness and Optimize Your Health*2018*384*414*4.7*15367*3*4"),
                new Book("11*Fantastic Beasts and Where to Find Them*2001*78*391*4.5*5772*12*2"),
                new Book("12*Harry Potter and the Chamber of Secrets*1998*251*299*4.7*31243*12*1"),
                new Book("13*Harry Potter and the Philosopher's Stone*1997*223*285.95*4.7*38252*12*7"),
                new Book("14*Harry Potter and the Prisoner of Azkaban*1999*317*158.65*4.7*24040*12*1"),
                new Book("15*How to Avoid a Climate Disaster: The Solutions We Have and the Breakthroughs We Need*2021*272749*4.6*7474*4*3"),
                new Book("16*Intensity: A powerful thriller of violence and terror*1996*480*324.33*4.4*1853*8*12"),
                new Book("17*Long Walk To Freedom*1994*630*456*4.6*3821*14*9"),
                new Book("18*Prisoners of Geography: Ten Maps That Tell You Everything You Need To Know About Global Politics*2015*320*479*4.6*6854*18*9"),
                new Book("19*Rich Dad Poor Dad*1997*336*291*4.5*3351*16*4"),
                new Book("20*She Has Her Mother's Laugh: The Powers, Perversions, and Potential of Heredity*2018*672*133.95*4.6*421*5*4"),
                new Book("21*The Origin of Species*1859*502*159*4.5*5414*6*6"),
                new Book("22*The Picture of Dorian Gray*1890*272*259*4.6*5763*15*7"),
                new Book("23*The Power of Geography: Ten Maps that Reveal the Future of Our World – the sequel to Prisoners of Geography*2021*380*381.99*4.6*1272*18*8"),
                new Book("24*The Tales of Beedle the Bard: A Harry Potter Hogwarts Library Book*2008*128*199*4.6*7692*12*11"),
                new Book("25*The Viscount Who Loved Me: Bridgerton*2000*354*257.34*4.5*24030*13*10"),
                new Book("26*Think Again: The Power of Knowing What You Don't Know*2021*320*505*4.6*6762*1*11"),
                new Book("27*When He Was Wicked: Bridgerton*2004*368*257.34*4.6*12991*13*5"),
            };

            // adding DbSeeds to the database
            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Book>().HasData(books);
        }
    }
}
