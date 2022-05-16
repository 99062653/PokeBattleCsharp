using EnergyTypeSpace;
using AttacksSpace;
using WeaknessSpace;
using ResistanceSpace;

namespace PokemonsSpace
{
	class Pokemons
	{
		public static List<Pokemon> Population = new List<Pokemon>();
		public static IDictionary<EnergyType, ConsoleColor> EnergytypeAndColors = new Dictionary<EnergyType, ConsoleColor>
		{
			{EnergyType.Normal, ConsoleColor.White},
			{EnergyType.Fire, ConsoleColor.Red},
			{EnergyType.Water, ConsoleColor.Blue},
			{EnergyType.Electric, ConsoleColor.Yellow},
			{EnergyType.Grass, ConsoleColor.Green},
			{EnergyType.Ice, ConsoleColor.Cyan},
			{EnergyType.Fighting, ConsoleColor.DarkRed},
			{EnergyType.Poison, ConsoleColor.DarkGreen},
			{EnergyType.Ground, ConsoleColor.DarkGray},
			{EnergyType.Flying, ConsoleColor.DarkGray},
			{EnergyType.Psychic, ConsoleColor.DarkGray},
			{EnergyType.Bug, ConsoleColor.DarkGray},
			{EnergyType.Rock, ConsoleColor.DarkGray},
			{EnergyType.Ghost, ConsoleColor.DarkGray},
			{EnergyType.Dragon, ConsoleColor.DarkGray},
			{EnergyType.Dark, ConsoleColor.DarkGray},
			{EnergyType.Steel, ConsoleColor.DarkGray},
			{EnergyType.Fairy, ConsoleColor.DarkGray}
		};

		public static List<Pokemon> GetPopulation()
		{
			return Population;
		}

		public static Pokemon getPokemonByName(string name) // ? zodat het null returns toestaat
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
		public string Name { get; set; }
		public EnergyType EnergyType { get; set; }
		public int Health { get; set; }
		public int HitPoints { get; set; }
		public IDictionary<string, int> Attacks = new Dictionary<string, int>();
		public IDictionary<string, int> Weakness = new Dictionary<string, int>();
		public IDictionary<string, int> Resistance = new Dictionary<string, int>();

		public Pokemon(string name, EnergyType energytype, int health, IDictionary<string, int> attacks, IDictionary<string, int> weakness, IDictionary<string, int> resistance)
		{
			this.Name = name;
			this.EnergyType = energytype;
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
			if (reciever.Weakness.ContainsKey(this.EnergyType.ToString())) //omdat het een enum nu is MOET het toString
			{
				attackdamage = attackdamage * reciever.Weakness[this.EnergyType.ToString()];
				reciever.HitPoints = reciever.HitPoints - attackdamage;
			}
			else if (reciever.Resistance.ContainsKey(this.EnergyType.ToString()))
			{
				attackdamage = attackdamage / reciever.Weakness[this.EnergyType.ToString()];
				reciever.HitPoints = reciever.HitPoints - attackdamage;
			} 
			else
			{
				reciever.HitPoints = reciever.HitPoints - attackdamage;
			}
			checkHp(reciever);
		}
	}

	class Init
	{
		public static void InitializePokemons()
		{
			//Console.WriteLine("Initializing Pokemons...");
			Pokemon Pikachu = new Pokemon("Pikachu", EnergyType.Electric, 72, new Dictionary<string, int> { { "Electric Shock", 50 }, { "Quick Attack", 25 } }, new Dictionary<string, int> { { "Water", 2 } }, new Dictionary<string, int> {{ "Electric", 2 }});
			Pokemon Bulbasaur = new Pokemon("Bulbasaur", EnergyType.Grass, 72, new Dictionary<string, int> { { "Vine Whip", 50 }, { "Tackle", 25 } }, new Dictionary<string, int> { { "Electric", 2 } }, new Dictionary<string, int> {{ "Grass", 2 }});

			Pokemons.Population = Pokemons.Population.OrderBy(i => Guid.NewGuid()).ToList(); //shuffle de lijst -> guid is een 128 character die nooit meer OPNIEUW gebruikt wordt
		}
	}
}