namespace PokemonNameSpace
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
		public List<Attack> Attacks { get; set; }
		public List<Weakness> Weaknesses { get; set; }
		public List<Resistance> Resistances { get; set; }

		public Pokemon(string name, EnergyType energytype, int health, List<Attack> attacks, List<Weakness> weaknesses, List<Resistance> resistances)
		{
			this.Name = name;
			this.EnergyType = energytype;
			this.Health = health;
			this.HitPoints = health;
			this.Attacks = attacks;
			this.Weaknesses = weaknesses;
			this.Resistances = resistances;

			Pokemon.Population.Add(this); // de HELE populatie
		}

		private void checkHp(Pokemon pokemon) // kijkt naar de HitPoints. en zet ze naar 0 als ze lager zijn dan 0
		{
			if (pokemon.HitPoints <= 0)
			{
				pokemon.HitPoints = 0;
				Pokemons.removePokemonFromPopulation(pokemon); // rip je bent dood pik
			}
		}

		public void attackPokemon(Pokemon reciever, Attack attack) // val andere pokemons aan NOG NODIG: WEAKNESS EN RESISTANCE!!!
		{
			if (reciever.Weaknesses.Any(w => w.EnergyType == this.EnergyType)) // w = weakness
			{
				attack.Damage = attack.Damage * 2;
			}
			else if (reciever.Resistances.Any(r => r.EnergyType == this.EnergyType)) // r = resistance
			{
				attack.Damage = attack.Damage / 2;
			} 
			else 
			{
				reciever.HitPoints = reciever.HitPoints - attack.Damage;
			}
			checkHp(reciever);
		}
	}
}