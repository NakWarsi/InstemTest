using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstemTest.Service;
using InstemTest.SharedSdk.Models;

namespace InstemTest.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieManagementController : ControllerBase
    {
        private readonly MovieManagerService _movieManagerService;

        public MovieManagementController(
            MovieManagerService movieManagerService)
        {
            _movieManagerService = movieManagerService;
        }

        [HttpGet("latest")]
        public async Task<IEnumerable<MovieSummery>> GetLatestMovies()
        {
            return await _movieManagerService.LatestMovies();
        }

        [HttpGet("all")]
        public async Task<IEnumerable<MovieSummery>> GetAllMovies()
        {
            return await _movieManagerService.AllMovies();
        }

        [HttpGet("summary/{searchString}")]
        public async Task<List<MovieSummery>> GetMatchedMovies(string searchString)
        {
            return await _movieManagerService.SearchMovies(searchString);
        }

        [HttpGet("{title}")]
        public async Task<Movie> GetMovieDetails(string title)
        {
            return await _movieManagerService.MovieDetails(title);
        }
    }
}
