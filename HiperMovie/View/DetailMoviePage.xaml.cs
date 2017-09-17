using HiperMovie.Model;
using HiperMovie.ViewModel;
using Xamarin.Forms;

namespace HiperMovie.View
{
    public partial class DetailMoviePage : ContentPage
    {
        public DetailMoviePage(Movie _movie)
        {
            InitializeComponent();
            BindingContext = new MovieDetailViewModel(_movie);
        }
    }
}
