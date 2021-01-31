using System;
using InstemTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using InstemTest.Services;

namespace InstemTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MoviesServiceProvider _moviesServiceProvider;
        public HomeController(
            ILogger<HomeController> logger,
            MoviesServiceProvider moviesServiceProvider)
        {
            _logger = logger;
            _moviesServiceProvider = moviesServiceProvider;
        }

        public IActionResult Index()
        {
            try
            {
                var topFourMovies = _moviesServiceProvider.GetTopFourMovies();
                return View(topFourMovies);
            }
            catch (Exception)
            {
                return View(null);
            }
        }

        public IActionResult MovieListView(string search)
        {
            try
            {
                var movies = _moviesServiceProvider.SearchMovies(search);
                return View(movies);
            }
            catch (Exception e)
            {
                return View(null);
            }
        }

        public IActionResult MovieDetailView(string movieName)
        {
            try
            {
                var movies = _moviesServiceProvider.GetFirstMatchedMovie(movieName);
                return View(movies);
            }
            catch (Exception e)
            {
                return View(null);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
