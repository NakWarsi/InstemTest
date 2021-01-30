﻿using InstemTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
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
            var topFourMovies = _moviesServiceProvider.GetTopFourMovies();
            return View(topFourMovies);
        }

        public IActionResult MovieListView(string search)
        {
            var movies = _moviesServiceProvider.SearchMovies(search);
            return View(movies);
        }

        public IActionResult MovieDetailView(string movieName)
        {
            var movies = _moviesServiceProvider.GetFirstMatchedMovie(movieName);
            return View(movies);
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