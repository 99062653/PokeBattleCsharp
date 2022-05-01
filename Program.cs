using Pokemons;

class Program 
{
	public static void Main()
	{
		Init.InitializePokemons();
		foreach (var pokemon in Pokemon.Population)
		{
			Console.WriteLine(pokemon.Name);
		}
		Console.ReadKey();

	}
}