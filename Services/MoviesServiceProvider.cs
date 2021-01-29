using System.Collections.Generic;
using System.IO;
using System.Linq;
using InstemTest.Models;
using Newtonsoft.Json;

namespace InstemTest.Services
{
    public class MoviesServiceProvider
    {
        private List<MovieDataModel> _allMovies;
        public MoviesServiceProvider()
        { 
            _allMovies = JsonConvert
                .DeserializeObject<List<MovieDataModel>>(File.ReadAllText(@"./Resouces/moviedata.json"));
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
            var topFour = _allMovies
                .OrderByDescending(x => x.Year)
                .Take(4)
                .ToList();
            return topFour;
        }
    }
}
