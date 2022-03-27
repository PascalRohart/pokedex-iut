using System;
using System.Collections.Generic;
using System.Text.Json;

namespace pokedexiut
{
    class Program
    {

        public static void ListePokemon() // Affiche toute la liste de Pokemons
        {
            Download.GetPokemons();
            foreach(Pokemon pokemon in Download.GetPokemons())
            {
                Console.WriteLine("ID: " + pokemon.id);
                Console.WriteLine("Name: " + pokemon.name.fr);
                Console.WriteLine("\n");
            }            
        }


        public static void TypesPokemonparGeneration()
        {

        }

        public static void AllPokemonByType(string type) // Affiche tout les pokemons d'un type
        {
            int idpokemon = 1;
            Console.WriteLine("Voici tous les pokemons de type: " + type);                           
            List<Pokemon> listebytype = new List<Pokemon>(); 
            foreach (Pokemon pokemon in Download.GetPokemons())
            {                                        
                if (pokemon.types.Contains(type))
                {
                    listebytype.Add(pokemon);
                }
                idpokemon++;                    
            }

            foreach (Pokemon pokemons in listebytype)
            {
                Console.WriteLine("ID: " + pokemons.id);
                Console.WriteLine("Name: " + pokemons.name.fr);
                Console.WriteLine("\n");
            }


            
        }

        public static float AVGWeightPokemonType(string type) // Affiche le poids moyen d'un type de Pokemon
        {
            float avgweight;
            float totalweight = 0;                       
            int idpokemon = 1;                
            List<Pokemon> listepokemontype = new List<Pokemon>();
            foreach (Pokemon pokemon in Download.GetPokemons())
            {
                if (pokemon.types.Contains(type))
                    listepokemontype.Add(pokemon);
                idpokemon++;
            }

            foreach (Pokemon pokemons in listepokemontype)
            {
                totalweight += pokemons.weight;
            }
            avgweight = totalweight / listepokemontype.Count;
            return avgweight;
            
        }

        public static void AffichePokemonByID(int id) // Affiche un Pokemon grâce à un id entré
        {
            var listepokemon = Download.GetPokemons();
            Pokemon pokemon = listepokemon.Find(p => p.id == id);
            Console.WriteLine("ID: " + pokemon.id);
            Console.WriteLine("Name: " + pokemon.name.fr);
            Console.Write("Type(s): ");
            foreach (string type in pokemon.types)
            {
                Console.Write(type + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Hauteur: " + pokemon.height + "m");
            Console.WriteLine("Poids: " + pokemon.weight + "kg");
            Console.WriteLine("Genus: " + pokemon.genus.fr);
            Console.WriteLine("Description: " + pokemon.description.fr);
            Console.WriteLine("\n");                            
        }

        static void Main(string[] args) // Main contient toutes les options du menu créé
        {
            int option;
            Download.Pokemons(); // On charge tout les pokemons avant de commencer à utiliser les options pour éviter d'avoir à télécharger la liste à chaque nouvelle option
            do
            {
                Console.WriteLine("Choisir une option: \n");
                Console.WriteLine("1: Afficher la liste des Pokemons (Numéro et Nom)");
                Console.WriteLine("2: Afficher la génération à laquelle appartient le pokemon choisi");
                Console.WriteLine("3: Afficher tous les Pokemons d'un type (au choix)");
                Console.WriteLine("4: Afficher tous les Pokemons de la génération 3");
                Console.WriteLine("5: Afficher la moyenne des poids des Pokémons par Type");
                Console.WriteLine("6: Afficher un Pokemon par son ID");
                Console.WriteLine("7: Afficher un pokemon de chaque type pour chaque génération");
                Console.WriteLine("8: Stopper le programme \n");
                option = int.Parse(Console.ReadLine());

                try
                {
                    switch (option)
                    {
                        case 1:
                            ListePokemon();
                            break;
                        case 2:
                            Console.WriteLine("Choisir un nombre");
                            int id = int.Parse(Console.ReadLine());
                            int gen = Generation.GetGenNumber(id);
                            Console.WriteLine("Ce pokemon est de la generation " + gen);
                            break;
                        case 3:
                            Console.WriteLine("Choisir un type");
                            string str = Console.ReadLine();
                            AllPokemonByType(str);
                            break;
                        case 4:
                            Generation.GetThirdGen();
                            break;
                        case 5:
                            Console.WriteLine("Choisir un type");
                            string str2 = Console.ReadLine();
                            float avg = AVGWeightPokemonType(str2);
                            Console.WriteLine("Le poids moyen des pokemons de types " + str2 + ": " + avg + "kg");
                            break;
                        case 6:
                            int num;
                            Console.WriteLine("Choisir un numero");
                            num = int.Parse(Console.ReadLine());
                            AffichePokemonByID(num);
                            break;
                        case 7:
                            Generation.GetAllTypesByGen();
                            break;
                    }
                }
                catch
                {
                }
   
                

            } while (option != 8);
                
        }
    }
}
