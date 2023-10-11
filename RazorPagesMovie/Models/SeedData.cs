using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesMovieContext>>()))
        {
            if (context == null || context.Book == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Book.Any())
            {
                return;   // DB has been seeded
            }

            context.Book.AddRange(
                new Book
                {
                    Title = "The Hunger Games",
                    Author = "Suzanne Collins",
                    ReleaseDate = DateTime.Parse("2008-9-14"),
                    Genre = "Dystopian",
                    Price = 12.79M
                },

                new Book
                {
                    Title = "Six of Crows",
                    Author = "Leigh Bardugo",
                    ReleaseDate = DateTime.Parse("2015-9-29"),
                    Genre = "Fantasy",
                    Price = 11.49M
                },

                new Book
                {
                    Title = "All the Light We Cannot See",
                    Author = "Anthony Doerr",
                    ReleaseDate = DateTime.Parse("2014-5-06"),
                    Genre = "Historical Fiction",
                    Price = 11.98M
                }
            );
            context.SaveChanges();
        }
    }
}