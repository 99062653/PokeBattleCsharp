namespace PokemonNameSpace
{
	class Attacks
	{
		public static List<Attack> AllAttacks = new List<Attack>(); //lijst met alle attacks

	}
	class Attack : Attacks
	{
		public string Name { get; set; } // naam van de attack
		public int Damage { get; set; } // damage van de attack
 		public EnergyType EnergyType { get; set; } // energytype van de attack

		public Attack(string name, int damage, EnergyType energytype)
		{
			this.Name = name;
			this.Damage = damage;
			this.EnergyType = energytype;

			Attacks.AllAttacks.Add(this); // ALLE ATTACKS
		}
	}
}