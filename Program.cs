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
	public static void Settings()
	{
		Console.Title = "Pokemon Battle"; //title van de console
		Console.CursorVisible = true; //toont de cursor

		//UNUSED
		//Console.Beep(); //speelt een beepje af
	}
	public static void Main()
	{
		Program.Settings();

		Console.WriteLine(Logo);
		Init.InitializePokemons();
		Pokemon.Population = Pokemon.Population.OrderBy(i => Guid.NewGuid()).ToList(); //shuffle de lijst -> guid is een 128 character die nooit meer gebruikt wordt
		foreach (var pokemon in Pokemon.Population)
		{
			Console.WriteLine(pokemon.Name);
			Thread.Sleep(500); // wacht 0.5 seconde
		}
		Console.ReadKey();
	}
}