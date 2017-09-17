using System;
using System.Diagnostics;
using HiperMovie.Model;

namespace HiperMovie.ViewModel
{
    public class MovieDetailViewModel
    {
        public Movie movie { get; set; }

        public MovieDetailViewModel(Movie _movie)
        {
            movie = _movie;
            Debug.WriteLine(@"Novo Movie: {0}", movie.title);
        }
    }
}
