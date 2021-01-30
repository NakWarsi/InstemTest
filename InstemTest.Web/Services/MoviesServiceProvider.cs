
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
        public MoviesServiceProvider()
        { 
            _client = new HttpClient();
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
            var getResponse = _client.GetAsync(ApiUrls.SearchMoviesApiUrl + searchSting).Result;
            var rawModelData = getResponse.Content.ReadAsStringAsync().Result;
            var responseDataFromServer = JsonConvert.DeserializeObject<List<MovieDataModel>>(rawModelData);
            return responseDataFromServer;
        }

        public MovieDataModel GetFirstMatchedMovie(string movieName)
        {
            var getResponse = _client.GetAsync(ApiUrls.movieDetailApiUrl + movieName).Result;
            var rawModelData = getResponse.Content.ReadAsStringAsync().Result;
            var responseDataFromServer = JsonConvert.DeserializeObject<MovieDataModel>(rawModelData);
            return responseDataFromServer;
        }
    }
}
