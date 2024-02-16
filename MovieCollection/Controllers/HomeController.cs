using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpPost]
        public IActionResult NewMovie(Movie response)
        {

            if (response.MovieSubCategory == null)
            {
                response.MovieSubCategory = "";
            }

            if (response.LentTo == null) 
            {
                response.LentTo = "";
            }

            if (response.Notes == null)
            {
                response.Notes = "";
            }

            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }
    }
}
