namespace PokemonNameSpace
{
    class Bulbasaur : Pokemon
    {
        public Bulbasaur(string name, EnergyType energytype, int health, List<Attack> attacks, List<Weakness> weaknesses, List<Resistance> resistances)
         : base(name, energytype, health, attacks, weaknesses, resistances)
        {
            this.Name = name;
            this.EnergyType = energytype;
            this.Health = health;
            this.HitPoints = health;
            this.Attacks = attacks;
            this.Weaknesses = weaknesses;
            this.Resistances = resistances;

            Pokemon.Population.Add(this); // hier voeg ik de pokemon toe aan de populatie
        }
    }
}