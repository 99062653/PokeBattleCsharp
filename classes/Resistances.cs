using EnergyTypeSpace;

namespace ResistanceSpace
{
	class Resistance
	{
		public EnergyType EnergyType { get; set; }
		public int Modifier { get; set; }

		public Resistance(EnergyType energytype, int modifier)
		{
			this.EnergyType = energytype;
			this.Modifier = modifier;
		}
	}
}