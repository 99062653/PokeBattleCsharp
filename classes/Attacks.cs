using MiscSpace;

namespace AttacksSpace
{
	class Attacks
	{
		public static List<Attack> AllAttacks = new List<Attack>();

	}
	class Attack : Attacks
	{
		public string Name { get; set; }
		public int Damage { get; set; }
		public EnergyType EnergyType { get; set; }

		public Attack(string name, int damage, EnergyType energytype)
		{
			this.Name = name;
			this.Damage = damage;
			this.EnergyType = energytype;

			Attacks.AllAttacks.Add(this); // de HELE populatie
		}
	}
}