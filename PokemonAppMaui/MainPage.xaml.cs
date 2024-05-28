using PokemonAppMaui.ViewModels;

namespace PokemonAppMaui
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageViewModel principalPageViewModel)
        {

            BindingContext = principalPageViewModel;
            InitializeComponent();

           
        }

    }

}
