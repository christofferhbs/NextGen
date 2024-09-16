namespace NextGen.POS.Services
{
    public class Payment
    {
        public double Amount { get; }

        public Payment(double cashTendered)
        {
            Amount = cashTendered;
        }
    }
}