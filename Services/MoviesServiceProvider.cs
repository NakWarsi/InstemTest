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
            List<MovieDataModel> matchedMovie = new List<MovieDataModel>();
            foreach (var row in _allMovies)
            {
                if (IfPatternExist(searchSting,row.Title))
                {
                    matchedMovie.Add(row);
                }
            }
            return matchedMovie;
        }

        private bool IfPatternExist(string patternArg, string txtArg)
        {

            var txt = txtArg.ToUpper();
            var pattern = patternArg.ToUpper();
            int patternLength = pattern.Length;
            int textLength = txt.Length;
            int textIndex = 0;

            while (textIndex <= textLength - patternLength)
            {
                int currentIndex;
                for (currentIndex = 0; currentIndex < patternLength; currentIndex++)
                {
                    if (txt[textIndex + currentIndex] != pattern[currentIndex])
                        break;
                }

                if (currentIndex == patternLength)
                {
                    return true;
                }
                else if (currentIndex == 0)
                    textIndex = textIndex + 1;
                else
                    textIndex = textIndex + currentIndex;
            }
            return false;
        }
    }
}
