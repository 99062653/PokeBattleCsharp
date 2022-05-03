using PokemonsSpace;

class Program
{
	public static IDictionary<int, Pokemon> NumberedPokemons = new Dictionary<int, Pokemon>();
	public static Pokemon PokemonFriendly;
	public static Pokemon PokemonEnemy;
	public static string Logo = @" 
	______     _       ______       _   _   _      
	| ___ \   | |      | ___ \     | | | | | |     
	| |_/ /__ | | _____| |_/ / __ _| |_| |_| | ___        ___  _      _     _  _        _                        
	|  __/ _ \| |/ / _ \ ___ \/ _` | __| __| |/ _ \      | _ \(_) __ | |__ | || | _  _ (_) ___ _ __   __ _  _ _  
	| | | (_) |   <  __/ |_/ / (_| | |_| |_| |  __/      |   /| |/ _|| / / | __ || || || |(_-<| '  \ / _` || ' \ 
	\_|  \___/|_|\_\___\____/ \__,_|\__|\__|_|\___|      |_|_\|_|\__||_\_\ |_||_| \_,_||_|/__/|_|_|_|\__,_||_||_|
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
		Pokemons.EnergytypeAndColors.TryGetValue(EnergyType, out CorrectColor);

		return CorrectColor;
	}

	public void displayColors(string energyColor)
	{
		Console.BackgroundColor = getColorByEnergyType(energyColor);
		Console.ForegroundColor = ConsoleColor.Black;
	}

	public void loadPokemon()
	{
		Program Game = new Program();
		var Group = Pokemons.Population;

		int numberCount = 0;
		foreach (var pokemon in Pokemons.Population)
		{
			numberCount++;
			NumberedPokemons.Add(numberCount, pokemon);
			Console.Write(numberCount + " " + pokemon.Name + ": ");
			displayColors(pokemon.EnergyType);
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
		else if (WhichPokemon == "Enemy")
		{
			Console.WriteLine("");
			Console.WriteLine("Type het NUMMER van de Pokemon waar je tegen wil spelen...");
		}

		string inputText = Console.ReadLine().ToString();
		if (inputText != "" && inputText != " " && inputText.All(char.IsDigit)) //niet leeg, en alle characters moeten een nummer zijn
		{
			int inputNumber = Convert.ToInt32(inputText);
			if (NumberedPokemons.ContainsKey(inputNumber))
			{
				ChosenPokemon = NumberedPokemons[inputNumber];
				Console.WriteLine("Gekozen Pokemon: " + ChosenPokemon.Name);

				Console.Write("-EnergyType: ");
				displayColors(ChosenPokemon.EnergyType);
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
					displayColors(weakness.Key);
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
					displayColors(resistance.Key);
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
					Console.WriteLine("");
					Console.WriteLine("Okay, kies opnieuw...");
					choosePokemon(WhichPokemon);
				}
				else
				{
					Console.WriteLine("");
					Console.WriteLine("Rare input! kies opnieuw...");
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
		IDictionary<int, Dictionary<string, int>> NumberedAttacks = new Dictionary<int, Dictionary<string, int>>();
		IDictionary<string, int> FriendlyAttacks = new Dictionary<string, int>();
		IDictionary<string, int> EnemyAttacks = new Dictionary<string, int>();
		Boolean yourTurn = true;
		int attacksCount = 0;

		Console.Clear();
		Console.ForegroundColor = ConsoleColor.Magenta;
		Console.WriteLine(Logo);
		Console.ResetColor();

		Console.BackgroundColor = ConsoleColor.Green;
		Console.ForegroundColor = ConsoleColor.Black;
		Console.Write(PokemonFriendly.Name);
		Console.ResetColor();
		Console.Write(" => " + PokemonFriendly.HitPoints + "/" + PokemonFriendly.Health);

		Console.Write(" vs ");

		Console.BackgroundColor = ConsoleColor.Red;
		Console.ForegroundColor = ConsoleColor.Black;
		Console.Write(PokemonEnemy.Name);
		Console.ResetColor();
		Console.Write(" => " + PokemonEnemy.HitPoints + "/" + PokemonEnemy.Health + "\n");

		if (yourTurn)
		{
			Console.WriteLine("Jij bent aan de beurt!");
			Console.Write("Attacks: ");
			foreach (KeyValuePair<string, int> attack in PokemonFriendly.Attacks)
			{
				attacksCount++;
				Console.Write(attacksCount + ": " + attack.Key + " => " + attack.Value + " ");
			}
		}
		Console.ReadKey();
	}

	public void startGame()
	{
		Program Game = new Program();
		Game.Settings();

		Console.WriteLine("Druk op ENTER om te starten en ESC om te stoppen...");
		ConsoleKey Button = Console.ReadKey().Key; //.Key is de knop die gedrukt is
		if (Button == ConsoleKey.Enter)
		{
			Init.InitializePokemons();
			Game.loadPokemon();
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
		else if (Button == ConsoleKey.Escape)
		{
			Environment.Exit(0); //Stopt het spel
		}
		else
		{
			Console.WriteLine("");
			Game.startGame();
		}
	}

	public static void Main()
	{
		Console.ForegroundColor = ConsoleColor.Magenta;
		Console.WriteLine(Logo);
		Console.ResetColor();

		Program actualGame = new Program();
		actualGame.startGame();
	}

}