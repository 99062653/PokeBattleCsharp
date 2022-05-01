using Pokemons;

class Program 
{
	public static void Main()
	{
		Initialize.Init();

		Pokemon Pikachu = new Pokemon("Pikachu", "Electric", 100, 100, new Dictionary<string, int>() { { "Thunder Shock", 50 } }, new Dictionary<string, int>() { { "Electric", 0 } }, new Dictionary<string, int>() { { "Fighting", 0 } });

		Console.WriteLine(Pikachu.Name);
	}
}