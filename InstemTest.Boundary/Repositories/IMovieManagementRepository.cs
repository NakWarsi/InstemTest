using System.Collections.Generic;
using System.Threading.Tasks;
using InstemTest.SharedSdk.Models;

namespace InstemTest.Boundary.Repositories
{
    public interface IMovieManagementRepository
    {
        Task<List<MovieSummery>> GetFourLatestMovies();
        Task<List<MovieSummery>> GetAllMovies();
        Task<Movie> GetMovieByTitle(string movieName);
    }
}
