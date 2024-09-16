namespace NextGen.POS.Models
{
    public class Moms
    {
        public double Rate { get; }

        public Moms(double rate)
        {
            Rate = rate;
        }

        public double CalculateMoms(double amount)
        {
            return amount * Rate;
        }

        public double CalculateTotalWithMoms(double amount)
        {
            return amount + CalculateMoms(amount);
        }
    }
}