using CommunityToolkit.Mvvm.ComponentModel;
using PokeApiNet;
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
        [ObservableProperty]
        private Pokemon pokemon;
    }
}
