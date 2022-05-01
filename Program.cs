using Pokemons;

class Program 
{

	// de reden dat dit zo naar links is omdat anders de ascii raar gaat doen
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

	public void getInfo()
	{

	}

	public void choosePokemon()
	{

	}

	public static void Main()
	{
		Program program = new Program();
		program.Settings();
		Console.WriteLine(Logo);
		Init.InitializePokemons();

		foreach (var pokemon in Pokemon.Population)
		{
			Console.WriteLine(pokemon.Name);
			Thread.Sleep(50); // laat het ff wachten
		}
		Console.WriteLine("Klaar! Druk op ENTER om verder te gaan.");
		ConsoleKey Button = Console.ReadKey().Key; //.Key is de knop die gedrukt is

		if (Button == ConsoleKey.Enter) 
		{

		}
	}
}