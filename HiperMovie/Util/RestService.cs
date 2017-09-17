using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HiperMovie.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HiperMovie.Util
{
    public class RestService : IRestMovieService
    {
        HttpClient client;

        //public List<Movie> Movies { get; private set; }
        public ResponseMovie responseMovie { get; set; }

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Movie>> GetMostPopularMovies(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            var uri = new Uri(Constants.BaseUrl + Constants.Discover);
            return await ExecuteTask(uri, ct);
        }

        public async Task<List<Movie>> SearchMovie(string text, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            var uri = new Uri(Constants.BaseUrl + Constants.Search + text);
			return await ExecuteTask(uri, ct);
        }

        public async Task<List<Movie>> ExecuteTask(Uri uri, CancellationToken ct)
        {
            //Movies = new List<Movie>();
            responseMovie = new ResponseMovie();
			try
			{
                ct.ThrowIfCancellationRequested();
                Debug.WriteLine(@"uri: {0}", uri.ToString());
				var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
                    var content = await response.Content.ReadAsStringAsync();
					//JObject json = JObject.Parse(content);
					//Debug.WriteLine(@"return: {0}", json["results"].ToString());
					//Movies = JsonConvert.DeserializeObject<List<Movie>>(json["results"].ToString());
					//Debug.WriteLine(@"Lines Count: {0}", Movies.Count);
                    Debug.WriteLine(@"return: {0}", content);
                    responseMovie = JsonConvert.DeserializeObject<ResponseMovie>(content);
				}
			}
			catch (System.OperationCanceledException ex)
			{
				Debug.WriteLine(@"ERROR: {0}", ex.Message);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"ERROR: {0}", ex.Message);
			}
            ct.ThrowIfCancellationRequested();
            return responseMovie.results;
        }
    }
}
