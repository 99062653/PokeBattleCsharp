namespace PokemonNameSpace
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
			
		}

		public static void InitializePokemons()
		{
			//Console.WriteLine("Initializing Pokemons...");
			Pikachu Pikachu = new Pikachu("Pikachu", EnergyType.Electric, 90, new List<Attack> { new Attack("Electric Shock", 50, EnergyType.Electric) }, new List<Weakness> { new Weakness(EnergyType.Water, 2) } , new List<Resistance> { new Resistance(EnergyType.Electric, 2) });
			Bulbasaur Bulbasaur = new Bulbasaur("Bulbasaur", EnergyType.Grass, 72, new List<Attack> { new Attack("Vine Whip", 50, EnergyType.Normal) }, new List<Weakness> { new Weakness(EnergyType.Fire, 2) } , new List<Resistance> { new Resistance(EnergyType.Grass, 2) });
			Charmander Charmander = new Charmander("Charmander", EnergyType.Fire, 85, new List<Attack> { new Attack("Quick Attack", 25, EnergyType.Normal) }, new List<Weakness> { new Weakness(EnergyType.Water, 2) } , new List<Resistance> { new Resistance(EnergyType.Fire, 2) });

			Pokemons.Population = Pokemons.Population.OrderBy(i => Guid.NewGuid()).ToList(); //shuffle de lijst -> guid is een 128 character die nooit meer OPNIEUW gebruikt wordt
		}
	}
}