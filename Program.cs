using Pokemons;

class Program 
{
	public static void Settings()
	{
		Console.Title = "Pokemon Battle"; //title van de console
		Console.CursorVisible = true; //toont de cursor
		Console.BackgroundColor = ConsoleColor.Red; //background color van de console: Black, White, Red etca
		Console.ForegroundColor = ConsoleColor.White; //foreground color van de console: Black, White, Red etca

		//UNUSED
		//Console.Beep(); //speelt een beepje af
	}
	public static void Main()
	{
		Program.Settings();
		Init.InitializePokemons();
		
		foreach (var pokemon in Pokemon.Population)
		{
			Console.WriteLine(pokemon.Name);
		}
		Console.ReadKey();

	}
}