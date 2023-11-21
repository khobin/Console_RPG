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
        public static readonly JsonManager instance = new JsonManager();

        //private Dictionary<string, Pokemon> pokemon_dic = new Dictionary<string, Pokemon>();
        private List<Pokemon> pokemon_list = new List<Pokemon>(100);

        private JsonManager() { }

        public void LoadPokemonData()
        {
            string json = File.ReadAllText("./test.json");

            Pokemon[]? pokemons = JsonConvert.DeserializeObject<Pokemon[]>(json);

            //this.pokemon_dic = pokemons.ToDictionary(x => x.Name);
            pokemon_list = pokemons.ToList<Pokemon>();
        }
        
        public Pokemon GetPokemonData(int id)
        {
            //Pokemon? p;
            //pokemon_dic.TryGetValue(name, out p);
            
            return pokemon_list[id];
        }

        //public Dictionary<string, Pokemon> GetAllData()
        //{
        //    return this.pokemon_dic;
        //}
        public List<Pokemon> GetAllData()
        {
            return this.pokemon_list;
        }
    }
}
