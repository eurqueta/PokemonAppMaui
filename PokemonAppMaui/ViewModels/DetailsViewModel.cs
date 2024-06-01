using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokeApiNet;
using PokemonAppMaui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAppMaui.ViewModels
{

    [QueryProperty("Pokemon", "pokemon")]
    public partial class DetailsViewModel : ObservableObject
    {

        public DetailsViewModel(PokeApiService service)
        {
            this.service = service;
            moves = new List<string>();
        }

        private readonly PokeApiService service;

        [ObservableProperty]
        private Pokemon? pokemon;
        [ObservableProperty]
        private string? pokedexEntry;
        [ObservableProperty]
        private string? generation;
        [ObservableProperty]
        private IEnumerable<string> moves;


        [RelayCommand]
        public async Task GetSpecies()
        {
            if(Pokemon is null)
            {
                return;
            }
            var species = await service.GetSpecies(this.Pokemon);
            this.PokedexEntry = species
                .FlavorTextEntries
                .FirstOrDefault(t => t.Language.Name.Equals("es"))?
                .FlavorText;
            this.Generation = species.Generation.Name;
        }

        [RelayCommand]
        public async Task GetMoves()
        {
            if (Pokemon is null)
            {
                return;
            }
            var moves = await service.GetMoves(this.Pokemon);
            this.Moves = moves
                .SelectMany(n => n.Names)
                .Where(name => name.Language.Name.Equals("es"))
                .Select(name => name.Name)
                .OrderBy(n => n);
        }

    }
}
