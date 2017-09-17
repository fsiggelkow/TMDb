using System;
using HiperMovie.Util;

namespace HiperMovie.Model
{
    public class Movie
    {
        public string vote_count { get; set; }
        public int id { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public string title { get; set; }
        public string popularity { get; set; }
        string _poster_path;
        public string poster_path { get { return _poster_path; } set { _poster_path = string.Format(Constants.PathImg, value); } }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public int[] genre_ids { get; set; }
        string _backdrop_path;
        public string backdrop_path { get { return _backdrop_path; } set { _backdrop_path = string.Format(Constants.PathImg, value); } }
        public bool adult { get; set; }
        public string overview { get; set; }
		DateTime _release_date;
        public DateTime release_date { get { return _release_date; } set { _release_date = Convert.ToDateTime(value); } }
    }
}
