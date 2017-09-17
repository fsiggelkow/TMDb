using System;
using System.Collections.Generic;

namespace HiperMovie.Model
{
    public class ResponseMovie
    {
        public string page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<Movie> results { get; set; }
    }
}
