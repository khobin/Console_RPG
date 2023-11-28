using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class JsonManager
    {
        private Dictionary<string, Pokemon> pokemon_dic = new Dictionary<string, Pokemon>(10);
        private Dictionary<string, Skill> skill_dic = new Dictionary<string, Skill>();
        public void LoadData()
        {
            //LoadSkill();
            //LoadPokemon();
        }
        
        public Pokemon GetPokemonData(string name)
        {
            Pokemon? p;
            pokemon_dic.TryGetValue(name, out p);

            return p;
        }

        public Dictionary<string, Pokemon> LoadPokemon()
        {
            string pokemonJson = File.ReadAllText("../../../docs/pokemon.json");
            Pokemon[]? pokemons = JsonConvert.DeserializeObject<Pokemon[]>(pokemonJson);
            pokemon_dic = pokemons.ToDictionary(x => x.Name);
            return pokemon_dic;
        }
        public Dictionary<string, Skill> LoadSkill()
        {
            string skillJson = File.ReadAllText("../../../docs/skill.json");
            Skill[]? skills = JsonConvert.DeserializeObject<Skill[]>(skillJson);
            skill_dic = skills.ToDictionary(x => x.Name);
            return skill_dic;
        }
    }
}
