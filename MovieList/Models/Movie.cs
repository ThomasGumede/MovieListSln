using System.ComponentModel.DataAnnotations;

namespace MovieList.Models;

public class Movie
{
    [Key]
    public int MovieId { get; set; }

    [Required(ErrorMessage = "Please enter a name.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Please enter a year.")]
    public int? Year { get; set; }

    [Required(ErrorMessage = "Please enter a rating.")]
    [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
    public int? Rating { get; set; }

    [Required(ErrorMessage = "Please enter a genre.")]
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }

    public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + Year?.ToString();
}
