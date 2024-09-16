namespace NextGen.POS.Services
{
    public class Payment
    {
        public double Amount { get; }

        public Payment(double cashTendered)
        {
            if (cashTendered <= 0)
            {
                throw new ArgumentException("Cash tendered must be greater than zero.");
            }

            Amount = cashTendered;
        }
    }
}