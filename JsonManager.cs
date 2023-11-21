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

        private Dictionary<string, Pokemon> pokemon_dic = new Dictionary<string, Pokemon>();

        public void LoadPokemonData()
        {
            string json = File.ReadAllText("../../../docs/test.json");

            Pokemon[]? pokemons = JsonConvert.DeserializeObject<Pokemon[]>(json);

            this.pokemon_dic = pokemons.ToDictionary(x => x.Name);
        }
        
        public Pokemon GetPokemonData(string name)
        {
            Pokemon? p;
            pokemon_dic.TryGetValue(name, out p);

            return p;
        }

        public Dictionary<string, Pokemon> GetAllData()
        {
            return this.pokemon_dic;
        }
    }
}
