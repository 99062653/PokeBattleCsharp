using EnergyTypeSpace;

namespace WeaknessSpace
{
	class Weakness
	{
		public EnergyType EnergyType { get; set; }
		public int Modifier { get; set; }

		public Weakness(EnergyType energytype, int modifier)
		{
			this.EnergyType = energytype;
			this.Modifier = modifier;
		}
	}
}