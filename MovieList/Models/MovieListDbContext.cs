using Microsoft.EntityFrameworkCore;

namespace MovieList.Models;

public class MovieListDbContext : DbContext
{
    public MovieListDbContext(DbContextOptions<MovieListDbContext> options) : base(options)
    {}

    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Genre>().HasData(
            new Genre { GenreId = 1, Name = "Action" },
            new Genre { GenreId = 2, Name = "Comedy" },
            new Genre { GenreId = 3, Name = "Drama" },
            new Genre { GenreId = 4, Name = "Horror" },
            new Genre { GenreId = 5, Name = "Musical" },
            new Genre { GenreId = 6, Name = "RomCom" },
            new Genre { GenreId = 7, Name = "SciFi" }
        );

        builder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 4,
                    Name = "Casablanca",
                    Year = 1943,
                    Rating = 5,
                    GenreId = 1
                },
                new Movie
                {
                    MovieId = 2,
                    Name = "Wonder Woman",
                    Year = 2017,
                    Rating = 3,
                    GenreId = 1
                },
                new Movie
                {
                    MovieId = 3,
                    Name = "Moonstruck",
                    Year = 1988,
                    Rating = 4,
                    GenreId = 6
                }
            );
    }
    
}
