using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedexiut
{
    public class PokemonStats
    {
        private int hp;
        private int attack;
        private int defense;
        private int specialAttack;
        private int specialDefense;
        private int speed;

        public PokemonStats(int hp, int attack, int defense, int specialAttack, int specialDefense, int speed)
        {
            this.hp = hp;
            this.attack = attack;
            this.defense = defense;
            this.specialAttack = specialAttack;
            this.specialDefense = specialDefense;
            this.speed = speed;
        }

    }
}
