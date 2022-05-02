using Pokemons;

class Program 
{

	// de reden dat dit zo naar links is omdat anders de ascii raar gaat doen

	public static Boolean loadFirstGenPokemons = true;
	public static Boolean loadSecondGenPokemons = false;
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

	public static void Main()
	{
		Program Game = new Program();
		Game.Settings();
		Console.WriteLine(Logo);
		Init.InitializePokemons();

		foreach (var pokemon in Pokemon.Population)
		{
			Console.Write(pokemon.Name + ": ");
			Console.BackgroundColor = Game.getColorByEnergyType(pokemon.EnergyType);
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Write(pokemon.EnergyType);
			Console.ResetColor();
			Console.Write(" => " + pokemon.HitPoints + "/" + pokemon.Health + "\r\n");
			
			//Console.WriteLine(pokemon.Name + ": " + pokemon.EnergyType + " => " + pokemon.HitPoints + "/" + pokemon.Health);
			Thread.Sleep(50); // laat het ff wachten, geeft een cool laad effect
		}
		Console.WriteLine("Klaar! Druk op ENTER om verder te gaan...");
		ConsoleKey Button = Console.ReadKey().Key; //.Key is de knop die gedrukt is

	}
}