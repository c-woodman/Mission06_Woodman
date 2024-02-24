using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Woodman.Models;
using System.Diagnostics;

namespace Mission06_Woodman.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp) 
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {

            ViewBag.Categories = _context.Categories.ToList();

            return View("NewMovie", new Movie());
        }

        [HttpPost]
        public IActionResult NewMovie(Movie response)
        {

            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }

            else
            {
                ViewBag.Categories = _context.Categories.ToList();

                return View(response);
            }

        }

        public IActionResult MovieList()
        {
            var movies = _context.Movies.Include(m => m.Category).ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .ToList();

            return View("NewMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie); 
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
