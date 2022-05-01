namespace Pokemons 
{
	class Pokemons 
	{
		public static string[] Population; 

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

		}
	}
	
	class Initialize 
	{
		public static void Init()
		{

		}
	}
}