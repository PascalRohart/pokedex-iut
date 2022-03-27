using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedexiut
{
    class Generation
    {
        private int idgen;

        public Generation(int idgen)
        {
            this.idgen = idgen;
        }

        public static int[,] Listegen() // Stocke les ID dans un tableau à deux dimensions avec comme troisième valeur le numéro de la génération
        {
            return new int[,]
            {
                {1, 151, 1},
                {152, 251, 2},
                {252, 386, 3},
                {387, 493, 4},
                {494, 649, 5},
                {650, 721, 6},
                {722, 802, 7},
                {803, 898, 8}
            };            
        }

        public static int GetGenNumber(int idpokemon) // Récupère le numéro de la génération correspondant à l'ID du pokemon
        {
            int[,] tabgen = Listegen();

            for (int i = 0; i < tabgen.Length; i++)
            {
                if (idpokemon >= tabgen[i,0] && idpokemon <= tabgen[i,1])
                {
                    return tabgen[i, 2];
                }
            }
            return 0;
        }

        public static void GetThirdGen() // Récupère les pokemons de la 3ème génération
        {
            int[,] tabgen = Listegen();
            var listepokemon = Download.GetPokemons();
            Pokemon pokemon;

            for (int i = tabgen[2,0]; i < tabgen[2,1]; i++)
            {
                pokemon = listepokemon.Find(p => p.id == i);
                Console.WriteLine("ID: " + pokemon.id);
                Console.WriteLine("Nom: " + pokemon.name.fr + "\n");

            }
        }  
        
        public static void GetAllTypesByGen() // Récupère tous les types de pokémon par génération
        {
            int[,] tabgen = Listegen();
            int premierindex = 0;                        
            var listepokemon = Download.GetPokemons();
            List<String> listetypes = new List<string>();
            for (int j = 0; j < 8; j++)
            {
                int minim = tabgen[premierindex, 0];
                int maxim = tabgen[premierindex, 1];
                for (int i = minim; i < maxim; i++)
                {
                    
                    Pokemon pokemon = listepokemon[i];
                    foreach (string type in pokemon.types)
                    {
                        if (listetypes.Contains(type) == false)
                        {
                            Console.WriteLine("ID: " + pokemon.id);
                            Console.WriteLine("Name: " + pokemon.name.fr);
                            Console.Write("Type: " + type + " ");

                            Console.WriteLine("\n---------------------------\n");
                            listetypes.Add(type);
                        }
                    }
                    
                }
                Console.WriteLine("\n==================== Changement de Génération ========================\n");


                premierindex++;
                listetypes.Clear();

            }           
        }


    }
}
