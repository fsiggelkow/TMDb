using HiperMovie.ViewModel;
using HiperMovie.Util;

using Xamarin.Forms;
using System.Windows.Input;
using HiperMovie.Model;
using System.Diagnostics;

namespace HiperMovie.View
{
    public partial class ListMoviePage : ContentPage
    {
        public ListMoviePage()
        {
            InitializeComponent();
            BindingContext = new MovieManagerViewModel(new RestService());
        }

        void HandleViewMovie(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e.Item == null) { return; }
			((ListView)sender).SelectedItem = null;
            var movie = e.Item as Movie;
            Debug.WriteLine(@"Clinck: {0}", movie.title);
            Navigation.PushAsync(new DetailMoviePage(movie));
            //DisplayAlert("Exibir Movie", string.Format("Você quer ver mais detalhes sobre ({0})", movie.title), "OK");
        }

        void HandleSearchActivated(object sender, System.EventArgs e)
        {
            DisplayAlert("Busca", "Vou mostrar uma caixa para a busca!", "OK");
        }
    }
}
