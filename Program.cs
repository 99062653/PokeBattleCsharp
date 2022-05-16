using MainSpace;
using PokemonsSpace;
using AttacksSpace;
using MiscSpace;

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

	public static void displayLogo()
	{
		Console.Clear();
		Console.ForegroundColor = ConsoleColor.Magenta;
		Console.WriteLine(Logo);
		Console.ResetColor();
	}

	public void Settings()
	{
		Console.Title = "Pokemon Battle"; //title van de console
		Console.CursorVisible = true; //toont de cursor
		Console.BackgroundColor = ConsoleColor.Black; //background color van de console
	}

	public ConsoleColor getColorByEnergyType(EnergyType EnergyType)
	{
		ConsoleColor CorrectColor;
		Pokemons.EnergytypeAndColors.TryGetValue(EnergyType, out CorrectColor);

		return CorrectColor;
	}

	public void displayColors(EnergyType energyColor)
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
			Console.WriteLine("\nType het NUMMER van de Pokemon die je wil spelen...");
		}
		else if (WhichPokemon == "Enemy")
		{
			Console.WriteLine("\nType het NUMMER van de Pokemon waar je tegen wil spelen...");
		}

		string inputText = Console.ReadLine();
		if (inputText != null && inputText != "" && inputText != " " && inputText.All(char.IsDigit)) //niet leeg, en alle characters moeten een nummer zijn
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
				foreach (var attack in ChosenPokemon.Attacks)
				{
					attackCount++;
					Console.WriteLine(" " + attackCount + ": " + attack.Name + " => " + attack.Damage);
					Thread.Sleep(50);
				}

				Console.WriteLine("-Weakness: ");
				int weaknessCount = 0;
				foreach (var weakness in ChosenPokemon.Weaknesses)
				{
					weaknessCount++;
					Console.Write(" " + weaknessCount + ": ");
					displayColors(weakness.EnergyType);
					Console.Write(weakness.EnergyType);
					Console.ResetColor();
					Console.Write(" => " + weakness.Modifier);
					Console.WriteLine("");
					Thread.Sleep(50);
				}

				Console.WriteLine("-Resistance: ");
				int resistanceCount = 0;
				foreach (var resistance in ChosenPokemon.Resistances)
				{
					resistanceCount++;
					Console.Write(" " + resistanceCount + ": ");
					displayColors(resistance.EnergyType);
					Console.Write(resistance.EnergyType);
					Console.ResetColor();
					Console.Write(" => " + resistance.Modifier);
					Console.WriteLine("");
					Thread.Sleep(50);
				}

				Console.WriteLine("\nTevreden met deze keuze? Y/N");
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

						if (PokemonFriendly != PokemonEnemy)
						{
							battlePokemon();
						}
						else
						{
							Console.WriteLine("\nJe mag niet 2 keer dezelfde pokemon kiezen!");
							choosePokemon(WhichPokemon);
						}
					}
				}
				else if (inputChoice == ConsoleKey.N)
				{
					Console.WriteLine("\nOkay, kies opnieuw...");
					choosePokemon(WhichPokemon);
				}
				else
				{
					Console.WriteLine("\nRare input! kies opnieuw...");
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
		IDictionary<int, Attack> FriendlyNumberedAttacks = new Dictionary<int, Attack>();
		IDictionary<int, Attack> EnemyNumberedAttacks = new Dictionary<int, Attack>();
		Boolean yourTurn = true;
		int attacksCount = 1; // 1 omdat hij anders bij 0 begint

		displayLogo();

		void displayPokemons()
		{
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
		}

		void displayAttack(Pokemon attacker, Pokemon reciever, Attack attack)
		{
			if (reciever.Weaknesses.Any(w => w.EnergyType == attacker.EnergyType)) // w = weakness
			{
				attack.Damage = attack.Damage * 2;
			}
			else if (reciever.Resistances.Any(r => r.EnergyType == attacker.EnergyType)) // r = resistance
			{
				attack.Damage = attack.Damage / 2;
			}

			Thread.Sleep(50); // laad effect
			Console.WriteLine("");
			if (attacker == PokemonFriendly)
			{
				Console.BackgroundColor = ConsoleColor.Green;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write(PokemonFriendly.Name);
				Console.ResetColor();
				Console.Write(" valt ");
				Console.BackgroundColor = ConsoleColor.Red;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write(PokemonEnemy.Name);
				Console.ResetColor();
				Console.Write(" aan met "); 
				Console.BackgroundColor = getColorByEnergyType(attack.EnergyType);
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write(attack.Name);
				Console.ResetColor();
				Console.Write(" en doet " + attack.Damage + " DP \n");
			}
			else
			{
				Console.BackgroundColor = ConsoleColor.Red;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write(PokemonEnemy.Name);
				Console.ResetColor();
				Console.Write(" valt ");
				Console.BackgroundColor = ConsoleColor.Green;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write(PokemonFriendly.Name);
				Console.ResetColor();
				Console.Write(" aan met "); 
				Console.BackgroundColor = getColorByEnergyType(attack.EnergyType);
				Console.ForegroundColor = ConsoleColor.Black;
				Console.Write(attack.Name);
				Console.ResetColor();
				Console.Write(" en doet " + attack.Damage + " DP \n");
			}
		}

		void clearAttacks()
		{
			FriendlyNumberedAttacks.Clear();
			EnemyNumberedAttacks.Clear();

			attacksCount = 1;
		}

		void chooseAttack()
		{
			Console.WriteLine("\nJij bent aan de beurt!");
			Console.Write("Attacks: ");
			foreach (var attack in PokemonFriendly.Attacks)
			{
				FriendlyNumberedAttacks.Add(attacksCount, attack);
				attacksCount++;
				Thread.Sleep(50); // laad effect
				Console.Write((attacksCount - 1) + ": " + attack.Name + " => " + attack.Damage + " "); // -1 want anders klopt het niet meer
			}
			Console.WriteLine("Kies je Attack...");
			string inputText = Console.ReadLine();
			if (inputText != null && inputText != "" && inputText != " " && inputText.All(char.IsDigit)) //niet leeg, en alle characters moeten een nummer zijn
			{
				int inputNumber = Convert.ToInt32(inputText);
				if (FriendlyNumberedAttacks.ContainsKey(inputNumber))
				{
					PokemonFriendly.attackPokemon(PokemonEnemy, FriendlyNumberedAttacks[inputNumber]);
					displayAttack(PokemonFriendly, PokemonEnemy, FriendlyNumberedAttacks[inputNumber]);
					displayPokemons();
					clearAttacks();
					yourTurn = false;
				}
				else 
				{
					Console.WriteLine("Dit is geen geldig nummer, probeer het opnieuw...");
					clearAttacks();
					chooseAttack();
				}
			}
			else
			{
				Console.WriteLine("Dit is geen geldig nummer, probeer het opnieuw...");
				clearAttacks();
				chooseAttack();
			}
		}
		displayPokemons();
		while (PokemonFriendly.HitPoints != 0 && PokemonEnemy.HitPoints != 0)
		{
			if (yourTurn)
			{
				chooseAttack();
			}
			else
			{
				foreach (var attack in PokemonEnemy.Attacks)
				{
					EnemyNumberedAttacks.Add(attacksCount, attack);
					attacksCount++;
				}

				Random random = new Random();
				int randomInt = random.Next(1, PokemonEnemy.Attacks.Count);

				PokemonEnemy.attackPokemon(PokemonFriendly, EnemyNumberedAttacks[randomInt]);
				displayAttack(PokemonEnemy, PokemonFriendly, EnemyNumberedAttacks[randomInt]);
				displayPokemons();
				yourTurn = true;
				clearAttacks();
			}
		}

		if (PokemonFriendly.HitPoints == 0)
		{
			Console.WriteLine("\nJe hebt verloren!");
		}
		else if (PokemonEnemy.HitPoints == 0)
		{
			Console.WriteLine("\nJe hebt gewonnen!");
		}
		Console.ReadKey();
		Main();
	}

	public void startGame()
	{
		Program Game = new Program();
		Game.Settings();
		NumberedPokemons.Clear();

		Console.WriteLine("Druk op ENTER om te starten en ESC om te stoppen...");
		ConsoleKey Button = Console.ReadKey().Key; //.Key is de knop die gedrukt is
		if (Button == ConsoleKey.Enter)
		{
			if (Pokemons.Population.Count == 0) // zodat de eerder doodgegaande pokemons niet TERUG komen
			{
				Init.InitializePokemons();
			}
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
		displayLogo();

		Program actualGame = new Program();
		actualGame.startGame();
	}

}