using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokeApiNet;
using PokemonAppMaui.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAppMaui.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel(PokeApiService service)
        {

            this.service = service;
            this.IsBusy = true;

        }

        private readonly PokeApiService service;
        private int page = -1;

        [ObservableProperty]
        ObservableCollection<Pokemon> pokemons = new ObservableCollection<Pokemon>();
        

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool isBusy;
 
        public bool IsNotBusy => !IsBusy;



        [RelayCommand]
        public async Task Next()
        {
            page++;
            this.IsBusy = true;

           var results = await service.GetAllPokemon(page);

            foreach (var pkmn in results)
            {
                
                this.Pokemons.Add(pkmn);
            }


            this.IsBusy = false;

        }

        [RelayCommand]
        public async Task GotoDetails(Pokemon pokemon)
        {
            if (pokemon is null)
            {
                return;
            }

            await Shell.Current.GoToAsync(nameof(DetailsPage),true,
                new Dictionary<string,object>
                {
                    { "pokemon", pokemon }
                });
        }
    }
}
