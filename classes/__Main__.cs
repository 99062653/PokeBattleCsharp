using PokemonsSpace;
using EnergyTypeSpace;
using AttacksSpace;
using WeaknessSpace;
using ResistanceSpace;

namespace MainSpace
{
	class Init
	{
		public static void InitializeAttacks()
		{
			//Console.WriteLine("Initializing Attacks...");
			Attack ElectricShock = new Attack("Electric Shock", 50, EnergyType.Electric);
			Attack VineWhip = new Attack("Vine Whip", 50, EnergyType.Normal);
			Attack QuickAttack  = new Attack("Quick Attack", 25, EnergyType.Normal);
			Attack Tackle = new Attack("Tackle", 25, EnergyType.Normal);

			InitializeAttacks();
		}

		public static void InitializePokemons()
		{
			//Console.WriteLine("Initializing Pokemons...");
			Pokemon Pikachu = new Pokemon("Pikachu", EnergyType.Electric, 72, new List<Attack> { Attacks.getAttackByName("Vine Whip") }, new List<Weakness> { new Weakness(EnergyType.Water, 2) } , new List<Resistance> { new Resistance(EnergyType.Electric, 2) });
			//Pokemon Bulbasaur = new Pokemon("Bulbasaur", EnergyType.Grass, 72, new Dictionary<string, int> { { "Vine Whip", 50 }, { "Tackle", 25 } }, new Dictionary<string, int> { { "Electric", 2 } }, new Dictionary<string, int> {{ "Grass", 2 }});

			Pokemons.Population = Pokemons.Population.OrderBy(i => Guid.NewGuid()).ToList(); //shuffle de lijst -> guid is een 128 character die nooit meer OPNIEUW gebruikt wordt
		}
	}
}