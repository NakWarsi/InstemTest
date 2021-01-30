using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstemTest.Boundary.Repositories;
using InstemTest.SharedSdk.Models;
using Newtonsoft.Json;

namespace InstemTest.Adapter
{
    public class MovieManagementResourceFileRepository : IMovieManagementRepository
    {
        private readonly List<Movie> _allMovies;

        public MovieManagementResourceFileRepository()
        {
            _allMovies = JsonConvert
                .DeserializeObject<List<Movie>>(File.ReadAllText(@"./Resources/moviedata.json"));

        }

        public async Task<List<MovieSummery>> GetFourLatestMovies()
        {
            var topFour = _allMovies
                .OrderByDescending(x => x.Year)
                .Take(4)
                .ToList();
            return topFour.Select(row => new MovieSummery {Title = row.Title, Year = row.Year}).ToList();
        }

        public async Task<List<MovieSummery>> GetAllMovies()
        {
            return _allMovies.Select(row => new MovieSummery {Title = row.Title, Year = row.Year}).ToList();
        }

        public async Task<Movie> GetMovieByTitle(string movieName)
        {
            return _allMovies.FirstOrDefault(x => x.Title == movieName);
        }
    }
}
