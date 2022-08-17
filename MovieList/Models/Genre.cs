using System.ComponentModel.DataAnnotations;

namespace MovieList.Models;

public class Genre
{
    [Key]
    public int GenreId { get; set; }

    [Required(ErrorMessage = "Name of genre is required")]
    public string? Name { get; set; }
}
