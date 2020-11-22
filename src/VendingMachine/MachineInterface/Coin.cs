namespace VendingMachine.MachineInterface
{
    public class Coin
    {
        public Coin(int weightMiligrams, int diameterMicrometre)
        {
            WeightMiligrams = weightMiligrams;
            DiameterMicrometre = diameterMicrometre;
        }

        public int WeightMiligrams { get; }
        public int DiameterMicrometre { get; }

        public override bool Equals(object obj)
        {
            return (obj is Coin) &&
                ((Coin)obj).DiameterMicrometre == DiameterMicrometre && 
                ((Coin)obj).WeightMiligrams == WeightMiligrams;
        }
    }
}