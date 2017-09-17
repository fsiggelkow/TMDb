using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HiperMovie.Model;

namespace HiperMovie.Util
{
    public interface IRestMovieService
    {
        Task<List<Movie>> GetMostPopularMovies(CancellationToken ct);
        Task<List<Movie>> SearchMovie(string text, CancellationToken ct);
    }
}