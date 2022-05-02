using Pokemons;

class Program
{
	public static Boolean loadFirstGenPokemons = true;
	public static Boolean loadSecondGenPokemons = true;
	public static Boolean loadThirdGenPokemons = true;

	public static IDictionary<int, Pokemon> NumberedPokemons = new Dictionary<int, Pokemon>();
	public static Pokemon PokemonFriendly;
	public static Pokemon PokemonEnemy;

	// de reden dat dit zo naar links is omdat anders de ascii raar gaat doen
	public static string Logo = @" 
	______     _       ______       _   _   _      
	| ___ \   | |      | ___ \     | | | | | |     
	| |_/ /__ | | _____| |_/ / __ _| |_| |_| | ___          ___  _      _     _  _        _                        
	|  __/ _ \| |/ / _ \ ___ \/ _` | __| __| |/ _ \        | _ \(_) __ | |__ | || | _  _ (_) ___ _ __   __ _  _ _  
	| | | (_) |   <  __/ |_/ / (_| | |_| |_| |  __/        |   /| |/ _|| / / | __ || || || |(_-<| '  \ / _` || ' \ 
	\_|  \___/|_|\_\___\____/ \__,_|\__|\__|_|\___|        |_|_\|_|\__||_\_\ |_||_| \_,_||_|/__/|_|_|_|\__,_||_||_|
	";

	public void Settings()
	{
		Console.Title = "Pokemon Battle"; //title van de console
		Console.CursorVisible = true; //toont de cursor
		Console.BackgroundColor = ConsoleColor.Black; //background color van de console
	}

	public ConsoleColor getColorByEnergyType(string EnergyType)
	{
		ConsoleColor CorrectColor;

		Pokemons.Pokemons.EnergytypeAndColors.TryGetValue(EnergyType, out CorrectColor);

		return CorrectColor;
	}

	public void loadPokemon(int generation)
	{
		Program Game = new Program();
		var Group = Pokemons.Pokemons.Population;
		switch (generation)
		{
			case 0:
				Group = Pokemons.Pokemons.Population;
				break;
			case 1:
				Group = Pokemons.Pokemons.PopulationFirstGen;
				break;
			case 2:
				Group = Pokemons.Pokemons.PopulationSecondGen;
				break;
			case 3:
				Group = Pokemons.Pokemons.PopulationThirdGen;
				break;
		}

		int numberCount = 0;
		foreach (var pokemon in Group)
		{
			numberCount++;
			NumberedPokemons.Add(numberCount, pokemon);
			Console.Write(numberCount + " " + pokemon.Name + ": ");
			Console.BackgroundColor = Game.getColorByEnergyType(pokemon.EnergyType);
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Write(pokemon.EnergyType);
			Console.ResetColor();
			Console.Write(" => " + pokemon.HitPoints + "/" + pokemon.Health + "\r\n");

			Thread.Sleep(50); // laat het ff wachten, geeft een cool laad effect
		}
	}

	public void choosePokemon(string WhichPokemon)
	{
		Pokemon ChosenPokemon;
		if (WhichPokemon == "Friendly")
		{
			Console.WriteLine("");
			Console.WriteLine("Type het NUMMER van de Pokemon die je wil spelen...");
		}
		else
		{
			Console.WriteLine("");
			Console.WriteLine("Type het NUMMER van de Pokemon waar je tegen wil spelen...");
		}

		string inputText = Console.ReadLine().ToString();
		if (inputText != "" && inputText != " ")
		{
			int inputNumber = Convert.ToInt32(inputText);
			if (NumberedPokemons.ContainsKey(inputNumber))
			{
				ChosenPokemon = NumberedPokemons[inputNumber];
				Console.WriteLine("Gekozen Pokemon: " + ChosenPokemon.Name);

				Console.Write("-EnergyType: ");
				Console.BackgroundColor = getColorByEnergyType(ChosenPokemon.EnergyType);
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write(ChosenPokemon.EnergyType);
				Console.ResetColor();

				Console.WriteLine("");
				Console.WriteLine("-HitPoints: " + ChosenPokemon.HitPoints);

				Console.WriteLine("-Attacks: ");
				int attackCount = 0;
				foreach (KeyValuePair<string, int> attack in ChosenPokemon.Attacks)
				{
					attackCount++;
					Console.WriteLine(" " + attackCount + ": " + attack.Key + " => " + attack.Value);
					Thread.Sleep(50);
				}

				Console.WriteLine("-Weakness: ");
				int weaknessCount = 0;
				foreach (KeyValuePair<string, int> weakness in ChosenPokemon.Weakness)
				{
					weaknessCount++;
					Console.Write(" " + weaknessCount + ": ");
					Console.BackgroundColor = getColorByEnergyType(weakness.Key);
					Console.ForegroundColor = ConsoleColor.Black;
					Console.Write(weakness.Key);
					Console.ResetColor();
					Console.Write(" => " + weakness.Value);
					Console.WriteLine("");
					Thread.Sleep(50);
				}

				Console.WriteLine("-Resistance: ");
				int resistanceCount = 0;
				foreach (KeyValuePair<string, int> resistance in ChosenPokemon.Resistance)
				{
					resistanceCount++;
					Console.Write(" " + resistanceCount + ": ");
					Console.BackgroundColor = getColorByEnergyType(resistance.Key);
					Console.ForegroundColor = ConsoleColor.Black;
					Console.Write(resistance.Key);
					Console.ResetColor();
					Console.Write(" => " + resistance.Value);
					Console.WriteLine("");
					Thread.Sleep(50);
				}
				Console.WriteLine("");

				Console.WriteLine("Tevreden met deze keuze? Y/N");
				ConsoleKey inputChoice = Console.ReadKey().Key;

				if (inputChoice == ConsoleKey.Y)
				{
					if (WhichPokemon == "Friendly")
					{
						PokemonFriendly = ChosenPokemon;
						choosePokemon("Enemy");
					}
					else
					{
						PokemonEnemy = ChosenPokemon;
						battlePokemon();
					}
				}
				else if (inputChoice == ConsoleKey.N)
				{
					Console.WriteLine(" Okay, kies opnieuw...");
					choosePokemon(WhichPokemon);
				}
			}
			else
			{
				Console.WriteLine("Dit is geen geldig nummer, probeer het opnieuw...");
				choosePokemon(WhichPokemon);
			}
		}
		else
		{
			Console.WriteLine("Dit is geen geldig nummer, probeer het opnieuw...");
			choosePokemon(WhichPokemon);
		}
	}

	public void battlePokemon()
	{
		List<int> friendlyAttacks = new List<int>();
		List<int> enemyAttacks = new List<int>();

		Console.Clear();
		Console.ForegroundColor = ConsoleColor.Magenta;
		Console.WriteLine(Logo);
		Console.ResetColor();

		Console.BackgroundColor = ConsoleColor.Green;
		Console.ForegroundColor = ConsoleColor.Black;
		Console.Write(PokemonFriendly.Name);
		Console.ResetColor();

		Console.Write(" vs ");

		Console.BackgroundColor = ConsoleColor.Red;
		Console.ForegroundColor = ConsoleColor.Black;
		Console.Write(PokemonEnemy.Name);
		Console.ResetColor();
		Console.WriteLine("");

		Console.ReadKey();

		foreach (int attackdamage in friendlyAttacks)
		{
			PokemonFriendly.attackPokemon(PokemonEnemy, attackdamage);
		}

		foreach (int attackdamage in enemyAttacks)
		{
			PokemonEnemy.attackPokemon(PokemonFriendly, attackdamage);
		}
	}

	public static void Main()
	{
		Program Game = new Program();
		Game.Settings();

		Console.ForegroundColor = ConsoleColor.Magenta;
		Console.WriteLine(Logo);
		Console.ResetColor();

		Init.InitializePokemons();

		Console.WriteLine("Druk op ENTER om te starten...");
		ConsoleKey Button = Console.ReadKey().Key; //.Key is de knop die gedrukt is
		if (Button == ConsoleKey.Enter)
		{
			Game.loadPokemon(0);
			Console.WriteLine("Klaar! Druk op een toets om verder te gaan...");

			Button = Console.ReadKey().Key;
			if (Button == ConsoleKey.Enter)
			{
				Game.choosePokemon("Friendly");
			}
			else
			{
				Game.choosePokemon("Friendly");
			}
		}
	}
}