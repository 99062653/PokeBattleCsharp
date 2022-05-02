namespace Pokemons 
{
	class Pokemons 
	{
		public static List<Pokemon> Population = new List<Pokemon>();
		public static List<Pokemon> PopulationFirstGen = new List<Pokemon>();
		public static List<Pokemon> PopulationSecondGen = new List<Pokemon>();
		public static List<Pokemon> PopulationThirdGen = new List<Pokemon>();
		public static IDictionary<string, ConsoleColor> EnergytypeAndColors = new Dictionary<string, ConsoleColor>
		{
			{"Normal", ConsoleColor.White},
			{"Fire", ConsoleColor.Red},
			{"Water", ConsoleColor.Blue},
			{"Electric", ConsoleColor.Yellow},
			{"Grass", ConsoleColor.Green},
			{"Ice", ConsoleColor.Cyan},
			{"Fighting", ConsoleColor.DarkRed},
			{"Poison", ConsoleColor.DarkGreen},
			{"Ground", ConsoleColor.DarkGray},
			{"Flying", ConsoleColor.DarkGray},
			{"Psychic", ConsoleColor.DarkGray},
			{"Bug", ConsoleColor.DarkGray},
			{"Rock", ConsoleColor.DarkGray},
			{"Ghost", ConsoleColor.DarkGray},
			{"Dragon", ConsoleColor.DarkGray},
			{"Dark", ConsoleColor.DarkGray},
			{"Steel", ConsoleColor.DarkGray},
			{"Fairy", ConsoleColor.DarkGray}
		};
		
		public static List<Pokemon> GetPopulation()
		{
			return Population;
		}

		public static Pokemon getPokemonByName(string name)
		{
			foreach (var pokemon in Population)
			{
				if (pokemon.Name == name)
				{
					return pokemon;
				}
			}
			return null;
		}
	}
	class Pokemon : Pokemons
	{
		public string Name = "";
		public string EnergyType = "";
		public int Health;
		public int HitPoints;
		public IDictionary<string, int> Attacks = new Dictionary<string, int>();
		public IDictionary<string, int> Weakness = new Dictionary<string, int>();
		public IDictionary<string, int> Resistance = new Dictionary<string, int>();
		public int Generation;
		
		public Pokemon(string name, string energyType, int health, int hitPoints, IDictionary<string, int> attacks, IDictionary<string, int> weakness, IDictionary<string, int> resistance, int generation)
		{
			this.Name = name;
			this.EnergyType = energyType;
			this.Health = health;
			this.HitPoints = health;
			this.Attacks = attacks;
			this.Weakness = weakness;
			this.Resistance = resistance;
			this.Generation = generation;

			Pokemon.Population.Add(this); // de HELE populatie

			switch (generation) //specifieke populatie
			{
				case 1:
					Pokemon.PopulationFirstGen.Add(this);
					break;
				case 2:
					Pokemon.PopulationSecondGen.Add(this);
					break;
				case 3:
					Pokemon.PopulationThirdGen.Add(this);
					break;
			}
		}
		
		public void attackPokemon(Pokemon enemypokemon, int attackdamage)
		{
			if (enemypokemon.Weakness.ContainsKey(this.EnergyType))
			{
				enemypokemon.HitPoints = enemypokemon.HitPoints - (attackdamage * enemypokemon.Weakness[this.EnergyType]);
			} 
			else if (enemypokemon.Resistance.ContainsKey(this.EnergyType))
			{
				enemypokemon.HitPoints = enemypokemon.HitPoints - (attackdamage * enemypokemon.Resistance[this.EnergyType]); // resistance werkt hetzelfde als weakness atm
			}
			else
			{
				enemypokemon.HitPoints = enemypokemon.HitPoints - attackdamage;
			}
		}
	}

	class Init
	{
		public static void InitializePokemons()
		{
			//Console.WriteLine("Initializing Pokemons...");

			// ALLE GENERATIE 1 POKEMONS
			if (Program.loadFirstGenPokemons) 
			{
				//Console.WriteLine("Initializing Generation 1 Pokemons...");
				Pokemon Bulbasaur = new Pokemon("Bulbasaur", "Grass", 45, 49, new Dictionary<string, int>() { { "Seed Bomb", 55 }, {"Sludge Bomb", 80} }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Ivysaur = new Pokemon("Ivysaur", "Grass", 60, 62, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Venusaur = new Pokemon("Venusaur", "Grass", 80, 82, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Charmander = new Pokemon("Charmander", "Fire", 39, 52, new Dictionary<string, int>() { { "Scratch", 1 } }, new Dictionary<string, int>() { { "Water", 2 } }, new Dictionary<string, int>() { { "Grass", 1 } }, 1);
				Pokemon Charmeleon = new Pokemon("Charmeleon", "Fire", 58, 64, new Dictionary<string, int>() { { "Scratch", 1 } }, new Dictionary<string, int>() { { "Water", 2 } }, new Dictionary<string, int>() { { "Grass", 1 } }, 1);
				Pokemon Charizard = new Pokemon("Charizard", "Fire", 78, 84, new Dictionary<string, int>() { { "Scratch", 1 } }, new Dictionary<string, int>() { { "Water", 2 } }, new Dictionary<string, int>() { { "Grass", 1 } }, 1);
				Pokemon Squirtle = new Pokemon("Squirtle", "Water", 44, 48, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Grass", 1 } }, 1);
				Pokemon Wartortle = new Pokemon("Wartortle", "Water", 59, 63, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Grass", 1 } }, 1);
				Pokemon Blastoise = new Pokemon("Blastoise", "Water", 79, 83, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Grass", 1 } }, 1);
				Pokemon Caterpie = new Pokemon("Caterpie", "Bug", 45, 30, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Metapod = new Pokemon("Metapod", "Bug", 50, 20, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Butterfree = new Pokemon("Butterfree", "Bug", 60, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Weedle = new Pokemon("Weedle", "Bug", 40, 35, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Kakuna = new Pokemon("Kakuna", "Bug", 50, 25, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Beedrill = new Pokemon("Beedrill", "Bug", 65, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Pidgey = new Pokemon("Pidgey", "Normal", 40, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Pidgeotto = new Pokemon("Pidgeotto", "Normal", 63, 60, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Pidgeot = new Pokemon("Pidgeot", "Normal", 83, 80, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Rattata = new Pokemon("Rattata", "Normal", 30, 56, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Raticate = new Pokemon("Raticate", "Normal", 55, 81, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Spearow = new Pokemon("Spearow", "Normal", 40, 60, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Fearow = new Pokemon("Fearow", "Normal", 65, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Ekans = new Pokemon("Ekans", "Poison", 35, 60, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Arbok = new Pokemon("Arbok", "Poison", 60, 85, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Pikachu = new Pokemon("Pikachu", "Electric", 35, 55, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Raichu = new Pokemon("Raichu", "Electric", 60, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Sandshrew = new Pokemon("Sandshrew", "Ground", 50, 75, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Sandslash = new Pokemon("Sandslash", "Ground", 75, 100, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Nidoran = new Pokemon("Nidoran", "Poison", 55, 47, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Nidorina = new Pokemon("Nidorina", "Poison", 70, 62, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Nidoqueen = new Pokemon("Nidoqueen", "Poison", 90, 82, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Nidorino = new Pokemon("Nidorino", "Poison", 60, 57, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Nidoking = new Pokemon("Nidoking", "Poison", 85, 72, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Clefairy = new Pokemon("Clefairy", "Normal", 70, 35, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Clefable = new Pokemon("Clefable", "Normal", 95, 70, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Vulpix = new Pokemon("Vulpix", "Fire", 38, 41, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Ninetales = new Pokemon("Ninetales", "Fire", 73, 76, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Jigglypuff = new Pokemon("Jigglypuff", "Normal", 115, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Wigglytuff = new Pokemon("Wigglytuff", "Normal", 140, 70, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Zubat = new Pokemon("Zubat", "Poison", 40, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Golbat = new Pokemon("Golbat", "Poison", 75, 80, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Oddish = new Pokemon("Oddish", "Grass", 45, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Gloom = new Pokemon("Gloom", "Grass", 60, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Vileplume = new Pokemon("Vileplume", "Grass", 75, 80, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Paras = new Pokemon("Paras", "Bug", 35, 70, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Parasect = new Pokemon("Parasect", "Bug", 60, 95, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Venonat = new Pokemon("Venonat", "Bug", 60, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Venomoth = new Pokemon("Venomoth", "Bug", 70, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Diglett = new Pokemon("Diglett", "Ground", 10, 55, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Dugtrio = new Pokemon("Dugtrio", "Ground", 35, 80, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Meowth = new Pokemon("Meowth", "Normal", 40, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Persian = new Pokemon("Persian", "Normal", 65, 70, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Psyduck = new Pokemon("Psyduck", "Water", 50, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Golduck = new Pokemon("Golduck", "Water", 80, 95, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Mankey = new Pokemon("Mankey", "Fighting", 40, 80, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Primeape = new Pokemon("Primeape", "Fighting", 65, 105, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Growlithe = new Pokemon("Growlithe", "Fire", 55, 70, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Arcanine = new Pokemon("Arcanine", "Fire", 90, 110, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Poliwag = new Pokemon("Poliwag", "Water", 40, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Poliwhirl = new Pokemon("Poliwhirl", "Water", 65, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Poliwrath = new Pokemon("Poliwrath", "Water", 90, 95, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Abra = new Pokemon("Abra", "Psychic", 25, 20, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Kadabra = new Pokemon("Kadabra", "Psychic", 40, 35, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Alakazam = new Pokemon("Alakazam", "Psychic", 55, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Machop = new Pokemon("Machop", "Fighting", 70, 80, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Machoke = new Pokemon("Machoke", "Fighting", 80, 100, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Machamp = new Pokemon("Machamp", "Fighting", 90, 130, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Bellsprout = new Pokemon("Bellsprout", "Grass", 50, 75, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Weepinbell = new Pokemon("Weepinbell", "Grass", 65, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Victreebel = new Pokemon("Victreebel", "Grass", 80, 105, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Tentacool = new Pokemon("Tentacool", "Water", 40, 40, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Tentacruel = new Pokemon("Tentacruel", "Water", 80, 70, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Geodude = new Pokemon("Geodude", "Rock", 40, 80, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Graveler = new Pokemon("Graveler", "Rock", 55, 95, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Golem = new Pokemon("Golem", "Rock", 80, 120, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Ponyta = new Pokemon("Ponyta", "Fire", 50, 85, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Rapidash = new Pokemon("Rapidash", "Fire", 65, 100, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Slowpoke = new Pokemon("Slowpoke", "Water", 90, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Slowbro = new Pokemon("Slowbro", "Water", 95, 75, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Magnemite = new Pokemon("Magnemite", "Electric", 25, 35, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Magneton = new Pokemon("Magneton", "Electric", 50, 60, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Farfetchd = new Pokemon("Farfetchd", "Normal", 52, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Doduo = new Pokemon("Doduo", "Normal", 35, 85, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Dodrio = new Pokemon("Dodrio", "Normal", 60, 110, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Seel = new Pokemon("Seel", "Water", 65, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Dewgong = new Pokemon("Dewgong", "Water", 90, 70, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Grimer = new Pokemon("Grimer", "Poison", 80, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Muk = new Pokemon("Muk", "Poison", 105, 75, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Shellder = new Pokemon("Shellder", "Water", 30, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Cloyster = new Pokemon("Cloyster", "Water", 50, 95, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Gastly = new Pokemon("Gastly", "Ghost", 30, 35, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Haunter = new Pokemon("Haunter", "Ghost", 45, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Gengar = new Pokemon("Gengar", "Ghost", 60, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Onix = new Pokemon("Onix", "Rock", 35, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Drowzee = new Pokemon("Drowzee", "Psychic", 60, 48, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Hypno = new Pokemon("Hypno", "Psychic", 85, 73, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Krabby = new Pokemon("Krabby", "Water", 30, 105, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Kingler = new Pokemon("Kingler", "Water", 55, 130, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Voltorb = new Pokemon("Voltorb", "Electric", 40, 30, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Electrode = new Pokemon("Electrode", "Electric", 60, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Exeggcute = new Pokemon("Exeggcute", "Grass", 60, 40, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Exeggutor = new Pokemon("Exeggutor", "Grass", 95, 95, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Cubone = new Pokemon("Cubone", "Ground", 50, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Marowak = new Pokemon("Marowak", "Ground", 60, 80, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Hitmonlee = new Pokemon("Hitmonlee", "Fighting", 50, 120, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Hitmonchan = new Pokemon("Hitmonchan", "Fighting", 50, 105, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Lickitung = new Pokemon("Lickitung", "Normal", 90, 55, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Koffing = new Pokemon("Koffing", "Poison", 40, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Weezing = new Pokemon("Weezing", "Poison", 65, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Rhyhorn = new Pokemon("Rhyhorn", "Ground", 80, 85, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Rhydon = new Pokemon("Rhydon", "Ground", 105, 130, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Chansey = new Pokemon("Chansey", "Normal", 250, 5, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Tangela = new Pokemon("Tangela", "Grass", 65, 55, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Kangaskhan = new Pokemon("Kangaskhan", "Normal", 105, 95, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Horsea = new Pokemon("Horsea", "Water", 30, 40, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Seadra = new Pokemon("Seadra", "Water", 55, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Goldeen = new Pokemon("Goldeen", "Water", 45, 67, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Seaking = new Pokemon("Seaking", "Water", 80, 92, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Staryu = new Pokemon("Staryu", "Water", 30, 55, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Starmie = new Pokemon("Starmie", "Water", 60, 75, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon MrMime = new Pokemon("Mr. Mime", "Psychic", 40, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Scyther = new Pokemon("Scyther", "Bug", 70, 55, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Jynx = new Pokemon("Jynx", "Ice", 65, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Electabuzz = new Pokemon("Electabuzz", "Electric", 65, 83, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Magmar = new Pokemon("Magmar", "Fire", 65, 95, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Pinsir = new Pokemon("Pinsir", "Bug", 65, 125, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Tauros = new Pokemon("Tauros", "Normal", 75, 95, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Magikarp = new Pokemon("Magikarp", "Water", 20, 10, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Gyarados = new Pokemon("Gyarados", "Water", 95, 125, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Lapras = new Pokemon("Lapras", "Water", 130, 85, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Ditto = new Pokemon("Ditto", "Normal", 48, 48, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Eevee = new Pokemon("Eevee", "Normal", 55, 55, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Vaporeon = new Pokemon("Vaporeon", "Water", 130, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Jolteon = new Pokemon("Jolteon", "Electric", 65, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Flareon = new Pokemon("Flareon", "Fire", 65, 130, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Porygon = new Pokemon("Porygon", "Normal", 65, 60, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Omanyte = new Pokemon("Omanyte", "Water", 35, 40, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Omastar = new Pokemon("Omastar", "Water", 70, 60, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Kabuto = new Pokemon("Kabuto", "Water", 30, 80, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Kabutops = new Pokemon("Kabutops", "Water", 60, 115, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Aerodactyl = new Pokemon("Aerodactyl", "Rock", 80, 105, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Snorlax = new Pokemon("Snorlax", "Normal", 160, 110, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Articuno = new Pokemon("Articuno", "Ice", 90, 85, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Zapdos = new Pokemon("Zapdos", "Electric", 90, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Moltres = new Pokemon("Moltres", "Fire", 90, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Dratini = new Pokemon("Dratini", "Dragon", 41, 64, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Dragonair = new Pokemon("Dragonair", "Dragon", 61, 84, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Dragonite = new Pokemon("Dragonite", "Dragon", 91, 134, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Mewtwo = new Pokemon("Mewtwo", "Psychic", 106, 110, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
				Pokemon Mew = new Pokemon("Mew", "Psychic", 100, 100, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 1);
			}

			//ALLE GENERATIE 2 POKEMONS 
			if (Program.loadSecondGenPokemons)
			{
				//Console.WriteLine("Initializing Generation 2 Pokemons...");
				Pokemon Chikorita = new Pokemon("Chikorita", "Grass", 45, 49, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Bayleef = new Pokemon("Bayleef", "Grass", 60, 62, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Meganium = new Pokemon("Meganium", "Grass", 80, 82, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Cyndaquil = new Pokemon("Cyndaquil", "Fire", 39, 52, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Quilava = new Pokemon("Quilava", "Fire", 58, 64, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Typhlosion = new Pokemon("Typhlosion", "Fire", 78, 84, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Totodile = new Pokemon("Totodile", "Water", 50, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Croconaw = new Pokemon("Croconaw", "Water", 65, 80, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Feraligatr = new Pokemon("Feraligatr", "Water", 85, 105, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Sentret = new Pokemon("Sentret", "Normal", 35, 46, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Furret = new Pokemon("Furret", "Normal", 85, 76, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Hoothoot = new Pokemon("Hoothoot", "Normal", 60, 30, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Noctowl = new Pokemon("Noctowl", "Normal", 100, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Ledyba = new Pokemon("Ledyba", "Bug", 40, 20, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Ledian = new Pokemon("Ledian", "Bug", 55, 35, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Spinarak = new Pokemon("Spinarak", "Bug", 40, 60, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Ariados = new Pokemon("Ariados", "Bug", 70, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Crobat = new Pokemon("Crobat", "Poison", 85, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Chinchou = new Pokemon("Chinchou", "Water", 75, 38, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Lanturn = new Pokemon("Lanturn", "Water", 125, 58, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Pichu = new Pokemon("Pichu", "Electric", 20, 40, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Cleffa = new Pokemon("Cleffa", "Normal", 50, 25, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Igglybuff = new Pokemon("Igglybuff", "Normal", 90, 30, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Togepi = new Pokemon("Togepi", "Normal", 35, 20, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Togetic = new Pokemon("Togetic", "Normal", 55, 40, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Natu = new Pokemon("Natu", "Psychic", 40, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Xatu = new Pokemon("Xatu", "Psychic", 65, 75, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Mareep = new Pokemon("Mareep", "Electric", 55, 40, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Flaaffy = new Pokemon("Flaaffy", "Electric", 70, 55, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Ampharos = new Pokemon("Ampharos", "Electric", 90, 75, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Bellossom = new Pokemon("Bellossom", "Grass", 75, 80, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Marill = new Pokemon("Marill", "Water", 40, 20, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Azumarill = new Pokemon("Azumarill", "Water", 100, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Sudowoodo = new Pokemon("Sudowoodo", "Rock", 70, 30, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Politoed = new Pokemon("Politoed", "Water", 90, 60, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Hoppip = new Pokemon("Hoppip", "Grass", 35, 35, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Skiploom = new Pokemon("Skiploom", "Grass", 55, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Jumpluff = new Pokemon("Jumpluff", "Grass", 75, 55, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Aipom = new Pokemon("Aipom", "Normal", 55, 55, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Sunkern = new Pokemon("Sunkern", "Grass", 30, 30, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Sunflora = new Pokemon("Sunflora", "Grass", 75, 75, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Yanma = new Pokemon("Yanma", "Bug", 65, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Wooper = new Pokemon("Wooper", "Water", 55, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Quagsire = new Pokemon("Quagsire", "Water", 95, 85, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Espeon = new Pokemon("Espeon", "Psychic", 65, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Umbreon = new Pokemon("Umbreon", "Dark", 95, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Murkrow = new Pokemon("Murkrow", "Dark", 60, 30, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Slowking = new Pokemon("Slowking", "Water", 95, 75, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Misdreavus = new Pokemon("Misdreavus", "Ghost", 60, 60, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Unown = new Pokemon("Unown", "Psychic", 48, 48, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Wobbuffet = new Pokemon("Wobbuffet", "Psychic", 190, 190, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Girafarig = new Pokemon("Girafarig", "Normal", 70, 80, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Pineco = new Pokemon("Pineco", "Bug", 50, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Forretress = new Pokemon("Forretress", "Bug", 75, 75, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Dunsparce = new Pokemon("Dunsparce", "Normal", 100, 100, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Gligar = new Pokemon("Gligar", "Ground", 65, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Steelix = new Pokemon("Steelix", "Steel", 75, 75, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Snubbull = new Pokemon("Snubbull", "Fairy", 60, 60, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Granbull = new Pokemon("Granbull", "Fairy", 90, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Qwilfish = new Pokemon("Qwilfish", "Water", 65, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Scizor = new Pokemon("Scizor", "Bug", 75, 75, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Shuckle = new Pokemon("Shuckle", "Bug", 20, 20, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Heracross = new Pokemon("Heracross", "Bug", 80, 80, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Sneasel = new Pokemon("Sneasel", "Dark", 55, 55, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Teddiursa = new Pokemon("Teddiursa", "Normal", 60, 60, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Ursaring = new Pokemon("Ursaring", "Normal", 90, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Slugma = new Pokemon("Slugma", "Fire", 40, 40, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Magcargo = new Pokemon("Magcargo", "Fire", 50, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Swinub = new Pokemon("Swinub", "Ice", 50, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Piloswine = new Pokemon("Piloswine", "Ice", 100, 100, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Corsola = new Pokemon("Corsola", "Water", 65, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Remoraid = new Pokemon("Remoraid", "Water", 35, 35, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Octillery = new Pokemon("Octillery", "Water", 75, 75, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Delibird = new Pokemon("Delibird", "Ice", 45, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Mantine = new Pokemon("Mantine", "Water", 65, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Skarmory = new Pokemon("Skarmory", "Steel", 65, 65, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Houndour = new Pokemon("Houndour", "Dark", 45, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Houndoom = new Pokemon("Houndoom", "Dark", 75, 75, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Kingdra = new Pokemon("Kingdra", "Water", 75, 75, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Phanpy = new Pokemon("Phanpy", "Ground", 90, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Donphan = new Pokemon("Donphan", "Ground", 90, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Porygon2 = new Pokemon("Porygon2", "Normal", 85, 85, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Stantler = new Pokemon("Stantler", "Normal", 73, 73, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Smeargle = new Pokemon("Smeargle", "Normal", 55, 55, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Tyrogue = new Pokemon("Tyrogue", "Fighting", 35, 35, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Hitmontop = new Pokemon("Hitmontop", "Fighting", 50, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Smoochum = new Pokemon("Smoochum", "Ice", 45, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Elekid = new Pokemon("Elekid", "Electric", 45, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Magby = new Pokemon("Magby", "Fire", 45, 45, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Miltank = new Pokemon("Miltank", "Normal", 95, 95, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Blissey = new Pokemon("Blissey", "Normal", 255, 255, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Raikou = new Pokemon("Raikou", "Electric", 90, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Entei = new Pokemon("Entei", "Fire", 90, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Suicune = new Pokemon("Suicune", "Water", 90, 90, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Larvitar = new Pokemon("Larvitar", "Rock", 50, 50, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Pupitar = new Pokemon("Pupitar", "Rock", 70, 70, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Tyranitar = new Pokemon("Tyranitar", "Rock", 100, 100, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Lugia = new Pokemon("Lugia", "Psychic", 106, 106, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon HoOh = new Pokemon("Ho-Oh", "Fire", 106, 106, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
				Pokemon Celebi = new Pokemon("Celebi", "Psychic", 100, 100, new Dictionary<string, int>() { { "Tackle", 1 } }, new Dictionary<string, int>() { { "Fire", 2 } }, new Dictionary<string, int>() { { "Water", 1 } }, 2);
			}

			if (Program.loadThirdGenPokemons)
			{

			}
			Pokemon.Population = Pokemon.Population.OrderBy(i => Guid.NewGuid()).ToList(); //shuffle de lijst -> guid is een 128 character die nooit meer gebruikt wordt
		}
	}
}