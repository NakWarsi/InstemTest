using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using InstemTest.SharedSdk.Models;

namespace InstemTest.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieManagementController : ControllerBase
    {
        private readonly ILogger<MovieManagementController> _logger;
        //private readonly MoviesServiceProvider _moviesServiceProvider;

        public MovieManagementController(
            ILogger<MovieManagementController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<MovieSummery> GetLatestMovies()
        {
            return null;
        }

        [HttpGet]
        public IEnumerable<MovieSummery> GetAllMovies()
        {
            return null;
        }

        [HttpGet("{Title}")]
        public Movie GetMovieDetails(string title)
        {
            return null;
        }
    }
}
