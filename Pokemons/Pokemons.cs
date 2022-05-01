namespace Pokemons 
{
	class Pokemons 
	{
		public static List<Pokemon> Population = new List<Pokemon>();

	}
	class Pokemon : Pokemons
	{
		public string Name = "";
		public string EnergyType = "";
		public int Health;
		public int HitPoints;
		public IDictionary<string, int> Attacks = new Dictionary<string, int>();
		public IDictionary<string, int> Weakness = new Dictionary<string, int>();
		public IDictionary<string, int> Resistance = new Dictionary<string, int>();

		public Pokemon(string name, string energyType, int health, int hitPoints, IDictionary<string, int> attacks, IDictionary<string, int> weakness, IDictionary<string, int> resistance)
		{
			this.Name = name;
			this.EnergyType = energyType;
			this.Health = health;
			this.HitPoints = hitPoints;
			this.Attacks = attacks;
			this.Weakness = weakness;
			this.Resistance = resistance;

			Pokemon.Population.Add(this);
		}
		
	}

	class Init
	{
		public static void InitializePokemons()
		{
			Console.WriteLine("Initializing Pokemon...");
			Pokemon Pikachu = new Pokemon("Pikachu", "Electric", 100, 100, new Dictionary<string, int>() { { "Thunder Shock", 50 } }, new Dictionary<string, int>() { { "Electric", 50 } }, new Dictionary<string, int>() { { "Fighting", 50 } });
			Pokemon Charmander = new Pokemon("Charmander", "Fire", 100, 100, new Dictionary<string, int>() { { "Ember", 50 } }, new Dictionary<string, int>() { { "Fire", 50 } }, new Dictionary<string, int>() { { "Water", 50 } });
			Pokemon Squirtle = new Pokemon("Squirtle", "Water", 100, 100, new Dictionary<string, int>() { { "Bubble", 50 } }, new Dictionary<string, int>() { { "Water", 50 } }, new Dictionary<string, int>() { { "Grass", 50 } });
			Pokemon Bulbasaur = new Pokemon("Bulbasaur", "Grass", 100, 100, new Dictionary<string, int>() { { "Vine Whip", 50 } }, new Dictionary<string, int>() { { "Grass", 50 } }, new Dictionary<string, int>() { { "Water", 50 } });
			Pokemon Pidgey = new Pokemon("Pidgey", "Normal", 100, 100, new Dictionary<string, int>() { { "Gust", 50 } }, new Dictionary<string, int>() { { "Normal", 50 } }, new Dictionary<string, int>() { { "Flying", 50 } });
			Pokemon Rattata = new Pokemon("Rattata", "Normal", 100, 100, new Dictionary<string, int>() { { "Tackle", 50 } }, new Dictionary<string, int>() { { "Normal", 50 } }, new Dictionary<string, int>() { { "Fighting", 50 } });
		}
	}
}