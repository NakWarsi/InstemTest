using System.Collections.Generic;
using System.Threading.Tasks;
using InstemTest.Boundary.Repositories;
using InstemTest.SharedSdk.Models;

namespace InstemTest.Service
{
    public class MovieManagerService
    {
        private readonly IMovieManagementRepository _movieManagementRepository;
        private readonly PatternMatcherService _patternMatcherService;
        public MovieManagerService(
            IMovieManagementRepository movieManagementRepository)
        {
            _movieManagementRepository = movieManagementRepository;
            _patternMatcherService = new PatternMatcherService();
        }

        public async Task<List<MovieSummery>> AllMovies()
        {
            return await _movieManagementRepository.GetAllMovies();
        }

        public async Task<List<MovieSummery>> LatestMovies()
        {
            return await _movieManagementRepository.GetFourLatestMovies();
        }

        public async Task<Movie> MovieDetails(string title)
        {
            return await _movieManagementRepository.GetMovieByTitle(title);
        }

        public async Task<List<MovieSummery>> SearchMovies(string searchSting)
        {
            var allMovies = await _movieManagementRepository.GetAllMovies();
            if (string.IsNullOrWhiteSpace(searchSting))
            {
                return allMovies;
            }

            var matchedMovie = new List<MovieSummery>();
            foreach (var row in allMovies)
            {
                if (_patternMatcherService.IfPatternExist(searchSting, row.Title))
                {
                    matchedMovie.Add(row);
                }
            }
            return matchedMovie;
        }
    }
}
