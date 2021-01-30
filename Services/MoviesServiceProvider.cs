using System.Collections.Generic;
using System.IO;
using System.Linq;
using InstemTest.Models;
using Newtonsoft.Json;

namespace InstemTest.Services
{
    public class MoviesServiceProvider
    {
        private readonly List<MovieDataModel> _allMovies;
        private readonly PatternMatcherService _patternMatcherService;
        public MoviesServiceProvider()
        { 
            _allMovies = JsonConvert
                .DeserializeObject<List<MovieDataModel>>(File.ReadAllText(@"./Resouces/moviedata.json"));
            _patternMatcherService = new PatternMatcherService();
        }

        public List<MovieDataModel> GetTopFourMovies()
        {
            
            var topFour = _allMovies
                .OrderByDescending(x => x.Year)
                .Take(4)
                .ToList();
            return topFour;
        }

        public List<MovieDataModel> SearchMovies(string searchSting)
        {
            if (string.IsNullOrWhiteSpace(searchSting))
            {
                return _allMovies;
            }
            List<MovieDataModel> matchedMovie = new List<MovieDataModel>();
            foreach (var row in _allMovies)
            {
                if (_patternMatcherService.IfPatternExist(searchSting,row.Title))
                {
                    matchedMovie.Add(row);
                }
            }
            return matchedMovie;
        }

        public MovieDataModel GetFirstMatchedMovie(string movieName)
        {
            return _allMovies.FirstOrDefault(x => x.Title == movieName);
        }
    }
}
