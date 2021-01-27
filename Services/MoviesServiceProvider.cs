using System.Collections.Generic;
using System.IO;
using System.Linq;
using InstemTest.Models;
using Newtonsoft.Json;

namespace InstemTest.Services
{
    public class MoviesServiceProvider
    {
        public List<MovieDataModel> GetTopFourMovies()
        {
            var allMovies = JsonConvert.DeserializeObject<List<MovieDataModel>>(File.ReadAllText(@"./Resouces/moviedata.json"));

            var topFour = allMovies
                .OrderByDescending(x => x.Year)
                .Take(4)
                .ToList();
            return topFour;
        }
    }
}
