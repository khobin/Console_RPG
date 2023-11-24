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

        private JsonManager() { }
        private static JsonManager instance = null;
        public static JsonManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new JsonManager();
                return instance;
            }
        }

        private Dictionary<string, Pokemon> pokemon_dic = new Dictionary<string, Pokemon>(10);
        private Dictionary<string, Skill> skill_dic = new Dictionary<string, Skill>();
        public void LoadData()
        {
            string pokemonJson = File.ReadAllText("../../../docs/pokemon.json");
            string skillJson = File.ReadAllText("../../../docs/skill.json");

            Skill[]? skills = JsonConvert.DeserializeObject<Skill[]>(skillJson);
            skill_dic = skills.ToDictionary(x => x.Name);
            Pokemon[]? pokemons = JsonConvert.DeserializeObject<Pokemon[]>(pokemonJson);
            pokemon_dic = pokemons.ToDictionary(x => x.Name);
        }
        
        public Pokemon GetPokemonData(string name)
        {
            Pokemon? p;
            pokemon_dic.TryGetValue(name, out p);

            return p;
        }

        public Dictionary<string, Pokemon> GetPokemonData()
        {
            return pokemon_dic;
        }
        public Dictionary<string, Skill> GetSkillData()
        {
            return skill_dic;
        }
    }
}
