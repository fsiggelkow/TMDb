using System;
namespace HiperMovie.Util
{
    public static class Constants
    {
        public static string BaseUrl = "https://api.themoviedb.org/3/";
        public static string Key = "c6288ab1d2b768d4464f13b5e1e6f2c7";
        public static string Discover = string.Format("discover/movie?api_key={0}&language=pt-BR&sort_by=popularity.desc", Key);
        public static string Search = string.Format("search/movie?api_key={0}&language=pt-BR&query=", Key);
        public static string PathImg = "http://image.tmdb.org/t/p/w185/{0}";
    }
}
