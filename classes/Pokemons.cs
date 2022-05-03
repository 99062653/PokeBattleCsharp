namespace PokemonsSpace
{
	class Pokemons
	{
		public static List<Pokemon> Population = new List<Pokemon>();
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

		public static void removePokemonFromPopulation(Pokemon pokemon)
		{
			Population.Remove(pokemon);
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

		public Pokemon(string name, string energyType, int health, int hitPoints, IDictionary<string, int> attacks, IDictionary<string, int> weakness, IDictionary<string, int> resistance)
		{
			this.Name = name;
			this.EnergyType = energyType;
			this.Health = health;
			this.HitPoints = health;
			this.Attacks = attacks;
			this.Weakness = weakness;
			this.Resistance = resistance;

			Pokemon.Population.Add(this); // de HELE populatie
		}

		public void checkHp(Pokemon pokemon) // kijkt naar de HitPoints. en zet ze naar 0 als ze lager zijn dan 0
		{
			if (pokemon.HitPoints <= 0)
			{
				pokemon.HitPoints = 0;
				Pokemons.removePokemonFromPopulation(pokemon); // rip je bent dood pik
			}
		}

		public void attackPokemon(Pokemon reciever, int attackdamage) // val andere pokemons aan NOG NODIG: WEAKNESS EN RESISTANCE!!!
		{
			reciever.HitPoints = reciever.HitPoints - attackdamage;
			checkHp(reciever);
		}
	}

	class Init
	{
		public static void InitializePokemons()
		{
			//Console.WriteLine("Initializing Pokemons...");
			Pokemon Bulbasaur = new Pokemon("Bulbasaur", "Grass", 100, 100, new Dictionary<string, int> { { "Seed Bomb", 25 }, { "Sludge Bomb", 40 }, { "Power Whip", 45 }, { "Frustration Shadow", 15 } }, new Dictionary<string, int> { { "Fire", 2 }, { "Grass", 0 } }, new Dictionary<string, int> { { "Fire", 0 }, { "Grass", 1 } });
			Pokemon Ivysaur = new Pokemon("Ivysaur", "Grass", 100, 100, new Dictionary<string, int> { { "Vine Whip", 30 }, { "Power Whip", 45 }, { "Sludge Bomb", 40 } }, new Dictionary<string, int> { { "Fire", 2 }, { "Grass", 0 } }, new Dictionary<string, int> { { "Fire", 0 }, { "Grass", 1 } });
			Pokemon Venusaur = new Pokemon("Venusaur", "Grass", 100, 100, new Dictionary<string, int> { { "Petal Blizzard", 100 }, { "Solar Beam", 180 }, { "Sludge Bomb", 40 } }, new Dictionary<string, int> { { "Fire", 2 }, { "Grass", 0 } }, new Dictionary<string, int> { { "Fire", 0 }, { "Grass", 1 } });

			Pokemons.Population = Pokemons.Population.OrderBy(i => Guid.NewGuid()).ToList(); //shuffle de lijst -> guid is een 128 character die nooit meer OPNIEUW gebruikt wordt
		}
	}
}