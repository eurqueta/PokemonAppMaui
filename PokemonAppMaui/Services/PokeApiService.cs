using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAppMaui.Services
{
    public class PokeApiService
    {
        private readonly PokeApiClient client;

        public PokeApiService(PokeApiClient client)
        {
            this.client = client;
        }

        public async Task<Pokemon> GetPokemon(int id)
        {
            return await client.GetResourceAsync<Pokemon>(id);
        }

        public async Task<List<Pokemon>> GetAllPokemon(int page)
        {
            List<Pokemon> pokemons = new List<Pokemon>();

            NamedApiResourceList<Pokemon> results = await client.GetNamedResourcePageAsync<Pokemon>(10,page*10);

            foreach (var pokemon in results.Results)
            {
                pokemons.Add(await client.GetResourceAsync<Pokemon>(pokemon));
            }

            return pokemons;
        }
    }
}
