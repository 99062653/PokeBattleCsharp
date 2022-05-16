namespace MiscSpace
{
	enum EnergyType //Kris vertelde mij om enums te gebruiken, handig!
	{
		Normal,
		Fire,
		Water,
		Electric,
		Grass,
		Ice,
		Fighting,
		Poison,
		Ground,
		Flying,
		Psychic,
		Bug,
		Rock,
		Ghost,
		Dragon,
		Dark,
		Steel,
		Fairy,
	}

	abstract class MiscValues //abstract classes zijn classes die alleen gemaakt zijn om gebruikt te worden door andere classes
	{
		public EnergyType EnergyType { get; set; }
		public int Modifier { get; set; }
	}

	class Resistance : MiscValues
	{
		public Resistance(EnergyType energytype, int modifier)
		{
			this.EnergyType = energytype;
			this.Modifier = modifier;
		}
	}

	class Weakness : MiscValues
	{
		public Weakness(EnergyType energytype, int modifier)
		{
			this.EnergyType = energytype;
			this.Modifier = modifier;
		}
	}
}