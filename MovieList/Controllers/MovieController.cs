using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieList.Models;

namespace MovieList.Controllers;


public class MovieController : Controller
{
    private readonly ILogger<MovieController> _logger;
    private readonly MovieListDbContext _context;

    public MovieController(ILogger<MovieController> logger, MovieListDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Details(int movieId)
    {

        Movie? movie = await _context.Movies.FindAsync(movieId);

        if (movie == null)
            return NotFound();

        return View(movie);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        IEnumerable<Genre> genres = await _context.Genres.ToListAsync();
        ViewBag.genres = new SelectList(genres, "GenreId", "Name");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Movie movie)
    {
        if (ModelState.IsValid)
        {
            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        IEnumerable<Genre> genres = await _context.Genres.ToListAsync();
        ViewBag.genres = new SelectList(genres, "GenreId", "Name");
        return View(movie);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int movieId)
    {
        IEnumerable<Genre> genres = await _context.Genres.ToListAsync();
        ViewBag.genres = new SelectList(genres, "GenreId", "Name");
        var movie = _context.Movies.Find(movieId);
        return View(movie);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        else
        {
            IEnumerable<Genre> genres = await _context.Genres.ToListAsync();
            ViewBag.genres = new SelectList(genres, "GenreId", "Name");
            return View(movie);
        }
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.Find(id);
        if(movie == null)
            return NotFound();
        return View(movie);
    }

    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }

}

