using Microsoft.EntityFrameworkCore.Migrations;

namespace OWT6BA_HFT_2022232.Repository.Database.Migrations
{
    public partial class BookDbSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "Adam Grant" },
                    { 18, "Tim Marshall" },
                    { 17, "Terry O'Brien" },
                    { 16, "Robert T Kiyosaki" },
                    { 14, "Nelson Mandela" },
                    { 13, "Julia Quinn" },
                    { 12, "J.K. Rowling" },
                    { 11, "George R.R. Martin" },
                    { 10, "George Orwell" },
                    { 15, "Oscar Wilde" },
                    { 8, "Dean Koontz" },
                    { 7, "Charles Dikens" },
                    { 6, "Charles Darwin" },
                    { 5, "Carl Zimmer" },
                    { 4, "Bill Gates" },
                    { 3, "Ben Lynch" },
                    { 2, "Barack Obama" },
                    { 9, "Franz Kafka" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 10, "Romance" },
                    { 9, "Politics" },
                    { 8, "Maps & Atlases" },
                    { 7, "Literature & Fiction" },
                    { 6, "History" },
                    { 2, "Film & Photography" },
                    { 4, "Health" },
                    { 3, "Internet & Digital Media" },
                    { 1, "Action & Adventure" },
                    { 11, "Society & Social Sciences" },
                    { 5, "Historical Fiction" },
                    { 12, "Travel" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "CategoryId", "NumberOfReviews", "Pages", "Price", "Rating", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 3, 11, 1, 11191, 761, 369.0, 4.5, 1998, "A Clash of Kings" },
                    { 25, 12, 11, 7692, 128, 199.0, 4.5999999999999996, 2008, "The Tales of Beedle the Bard: A Harry Potter Hogwarts Library Book" },
                    { 1, 10, 11, 61318, 328, 79.0, 4.5, 1949, "1984" },
                    { 26, 13, 10, 24030, 354, 257.33999999999997, 4.5, 2000, "The Viscount Who Loved Me: Bridgerton" },
                    { 19, 18, 9, 6854, 320, 479.0, 4.5999999999999996, 2015, "Prisoners of Geography: Ten Maps That Tell You Everything You Need To Know About Global Politics" },
                    { 17, 14, 9, 3821, 630, 456.0, 4.5999999999999996, 1994, "Long Walk To Freedom" },
                    { 5, 2, 9, 1217, 768, 184.0, 4.7000000000000002, 2020, "A Promised Land" },
                    { 24, 18, 8, 1272, 380, 381.99000000000001, 4.5999999999999996, 2021, "The Power of Geography: Ten Maps that Reveal the Future of Our World – the sequel to Prisoners of Geography" },
                    { 23, 15, 7, 5763, 272, 259.0, 4.5999999999999996, 1890, "The Picture of Dorian Gray" },
                    { 18, 9, 7, 6279, 217, 79.0, 4.5, 1915, "Metamorphosis" },
                    { 13, 12, 7, 38252, 223, 285.94999999999999, 4.7000000000000002, 1997, "Harry Potter and the Philosopher's Stone" },
                    { 8, 10, 7, 33951, 112, 99.0, 4.5999999999999996, 1945, "Animal Farm" },
                    { 2, 17, 7, 578, 600, 203.30000000000001, 4.2999999999999998, 2015, "50 Greatest Short Stories" },
                    { 22, 6, 6, 5414, 502, 159.0, 4.5, 1859, "The Origin of Species" },
                    { 28, 13, 5, 12991, 368, 257.33999999999997, 4.5999999999999996, 2004, "When He Was Wicked: Bridgerton" },
                    { 7, 13, 5, 17090, 358, 294.04000000000002, 4.5999999999999996, 2001, "An Offer From a Gentleman: Bridgerton" },
                    { 6, 7, 5, 4721, 304, 159.0, 4.5, 1859, "A Tale of Two Cities" },
                    { 21, 5, 4, 421, 672, 133.94999999999999, 4.5999999999999996, 2018, "She Has Her Mother's Laugh: The Powers, Perversions, and Potential of Heredity" },
                    { 20, 16, 4, 3351, 336, 291.0, 4.5, 1997, "Rich Dad Poor Dad" },
                    { 10, 3, 4, 15367, 384, 414.0, 4.7000000000000002, 2018, "Dirty Genes: A Breakthrough Program to Treat the Root Cause of Illness and Optimize Your Health" },
                    { 15, 4, 3, 7474, 272, 749.0, 4.5999999999999996, 2021, "How to Avoid a Climate Disaster: The Solutions We Have and the Breakthroughs We Need" },
                    { 11, 12, 2, 5772, 78, 391.0, 4.5, 2001, "Fantastic Beasts and Where to Find Them" },
                    { 14, 12, 1, 24040, 317, 158.65000000000001, 4.7000000000000002, 1999, "Harry Potter and the Prisoner of Azkaban" },
                    { 12, 12, 1, 31243, 251, 299.0, 4.7000000000000002, 1998, "Harry Potter and the Chamber of Secrets" },
                    { 9, 13, 1, 30616, 339, 399.0, 4.5, 2000, "Bridgerton: The Duke and I" },
                    { 4, 11, 1, 2188, 694, 449.0, 4.5, 1996, "A Game of Thrones" },
                    { 27, 1, 11, 6762, 320, 505.0, 4.5999999999999996, 2021, "Think Again: The Power of Knowing What You Don't Know" },
                    { 16, 8, 12, 1853, 480, 324.32999999999998, 4.4000000000000004, 1996, "Intensity: A powerful thriller of violence and terror" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12);
        }
    }
}
