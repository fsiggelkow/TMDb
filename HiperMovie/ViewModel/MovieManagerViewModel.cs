using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using HiperMovie.Model;
using HiperMovie.Util;
using Xamarin.Forms;

namespace HiperMovie.ViewModel
{
    public class MovieManagerViewModel : ObservableProperty
    {
        IRestMovieService RestService;
        ObservableCollection<Movie> _movies;
        public ICommand SeachMovieCommand { get; private set; }
		public ICommand RefreshCommand
		{
			get
			{
				return new Command(() =>
				{
					IsRefreshing = true;

                    SetPopularMovies();

					IsRefreshing = false;
				});
			}
		}

        public ObservableCollection<Movie> Movies
        {
            get { return _movies; }
            set 
            {
                _movies = value;
                OnPropertyChanged("Movies");
            }
        }

		private bool _isRefreshing = false;
		public bool IsRefreshing
		{
			get { return _isRefreshing; }
			set
			{
				_isRefreshing = value;
				OnPropertyChanged(nameof(IsRefreshing));
			}
		}

        CancellationTokenSource cts;

        public MovieManagerViewModel(IRestMovieService service)
        {
            RestService = service;
            cts = new CancellationTokenSource();
            SeachMovieCommand = new Command<string>(SeachMovie);
            SetPopularMovies();
        }

        private void SetPopularMovies()
        {
            var ct = cts.Token;
            Task.Run(async() => {
                try
                {
                    _movies = new ObservableCollection<Movie>(await RestService.GetMostPopularMovies(ct) as List<Movie>);
                    Debug.WriteLine(@"Update list to new ({0}) movies", Movies.Count);
                    //OnPropertyChanged("_movies");
                    OnPropertyChanged("Movies");
                    foreach(var mov in Movies){
                        Debug.WriteLine(@"Movie: {0}", mov.title);
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
            }, ct);
        }

        void SeachMovie(string text)
        {

            Debug.WriteLine(@"Buscar por: {0}", text);
			var ct = cts.Token;
			Task.Run(async () => {
				try
				{
                    _movies = new ObservableCollection<Movie>(await RestService.SearchMovie(text,ct) as List<Movie>);
					Debug.WriteLine(@"Update list to new ({0}) movies", Movies.Count);
					//OnPropertyChanged("_movies");
					OnPropertyChanged("Movies");
					foreach (var mov in Movies)
					{
						Debug.WriteLine(@"Movie: {0}", mov.title);
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
			}, ct);
        }
    }
}
