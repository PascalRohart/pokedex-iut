using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedexiut
{
    class Download
    {
        private static List<Pokemon> listePokemon;

        public static void Pokemons() // Télécharge la liste de Pokemon en ajoutant dans une autre liste les pokemon un par un
        {
            int idpokemon = 1;
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                string jsonString = webClient.DownloadString("https://tmare.ndelpech.fr/tps/pokemons");
                JSONPokemon[] jsonpokemon = JsonSerializer.Deserialize<JSONPokemon[]>(jsonString);
                listePokemon = new List<Pokemon>();
                Pokemon pokemon;
                foreach (JSONPokemon json in jsonpokemon)
                {
                    jsonString = webClient.DownloadString("https://tmare.ndelpech.fr/tps/pokemons/" + idpokemon);
                    pokemon = JsonSerializer.Deserialize<Pokemon>(jsonString);
                    listePokemon.Add(pokemon);
                    idpokemon++;
                }
            }
        }

        public static List<Pokemon> GetPokemons() // Retourne une liste qui contient tous les Pokemons
        {
            return listePokemon;
        }
    }
}
