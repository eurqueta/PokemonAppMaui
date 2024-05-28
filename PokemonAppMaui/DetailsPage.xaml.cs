using PokeApiNet;

namespace PokemonAppMaui;


public partial class DetailsPage : ContentPage
{


	public DetailsPage(DetailsViewModel detailsViewModel)
	{
		InitializeComponent();

		BindingContext = detailsViewModel;
	}
}