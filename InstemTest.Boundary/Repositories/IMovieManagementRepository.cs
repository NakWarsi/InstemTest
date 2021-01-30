using System.Collections.Generic;
using System.Threading.Tasks;
using InstemTest.SharedSdk.Models;

namespace InstemTest.Boundary.Repositories
{
    public interface IMovieManagementRepository
    {
        Task<List<Movie>> GetFourLatestMovies();
        Task<List<Movie>> SearchMovies(string searchSting);
        Task<Movie> GetMovieByTitle(string movieName);
    }
}
