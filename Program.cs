using Pokemons;

class Program 
{

	// de reden dat dit zo naar links is omdat anders de ascii raar gaat doen

	public static Boolean loadFirstGenPokemons = true;
	public static Boolean loadSecondGenPokemons = true;
	public static Boolean loadThirdGenPokemons = false;

	public static string Logo = @" 
______     _       ______       _   _   _      
| ___ \   | |      | ___ \     | | | | | |     
| |_/ /__ | | _____| |_/ / __ _| |_| |_| | ___ 
|  __/ _ \| |/ / _ \ ___ \/ _` | __| __| |/ _ \
| | | (_) |   <  __/ |_/ / (_| | |_| |_| |  __/
\_|  \___/|_|\_\___\____/ \__,_|\__|\__|_|\___|
	";
	
	public void Settings()
	{
		Console.Title = "Pokemon Battle"; //title van de console
		Console.CursorVisible = true; //toont de cursor
		Console.BackgroundColor = ConsoleColor.Black; //background color van de console

		//UNUSED
		//Console.Beep(); //speelt een beepje af
	}

	public ConsoleColor getColorByEnergyType(string EnergyType)
	{
		ConsoleColor CorrectColor;

		Pokemons.Pokemons.EnergytypeAndColors.TryGetValue(EnergyType, out CorrectColor);

		return CorrectColor;
	}

	public void getInfo()
	{

	}

	public void searchPokemon()
	{
		Console.WriteLine("Zoek je pokemon op...");
		Console.ReadLine();
	}

	public void choosePokemon()
	{

	}

	public void loadPokemon(int generation)
	{
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
		Program Game = new Program();
		foreach (var pokemon in Group)
		{
			Console.Write(pokemon.Name + ": ");
			Console.BackgroundColor = Game.getColorByEnergyType(pokemon.EnergyType);
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Write(pokemon.EnergyType);
			Console.ResetColor();
			Console.Write(" => " + pokemon.HitPoints + "/" + pokemon.Health + "\r\n");
			
			Thread.Sleep(50); // laat het ff wachten, geeft een cool laad effect
		}
		Console.WriteLine("Klaar! Druk op ENTER om verder te gaan...");
	}

	public static void Main()
	{
		Program Game = new Program();
		Game.Settings();
		Console.WriteLine(Logo);
		Init.InitializePokemons();

		Console.WriteLine("Druk op ENTER om te starten...");
		ConsoleKey Button = Console.ReadKey().Key; //.Key is de knop die gedrukt is
		if (Button == ConsoleKey.Enter)
		{
			Game.loadPokemon(0);
			Console.ReadKey();
		}
	}
}