
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InstemTest.Models;
using InstemTest.Web.Resources;
using Newtonsoft.Json;

namespace InstemTest.Services
{
    public class MoviesServiceProvider
    {
        private readonly HttpClient _client;
        private readonly PatternMatcherService _patternMatcherService;
        public MoviesServiceProvider()
        { 
            _client = new HttpClient();
            _patternMatcherService = new PatternMatcherService();
        }

        public List<MovieDataModel> GetTopFourMovies()
        {
            var getResponse = _client.GetAsync(ApiUrls.LatestMoviesApiUrl).Result;
            var rawModelData = getResponse.Content.ReadAsStringAsync().Result;
            var responseDataFromServer = JsonConvert.DeserializeObject<List<MovieDataModel>>(rawModelData);
            return responseDataFromServer;
        }

        public List<MovieDataModel> SearchMovies(string searchSting)
        {
            
            return null;
        }

        public MovieDataModel GetFirstMatchedMovie(string movieName)
        {
            return  null;
        }
    }
}
