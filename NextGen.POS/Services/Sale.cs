using NextGen.POS.Models;

namespace NextGen.POS.Services
{
    public class Sale
    {
        private List<SalesLineItem> _lineItems = new List<SalesLineItem>();
        private bool _isComplete = false;
        private Payment _payment;
        private CustomerDescription _customerDescription;
        private Moms _moms;
        private double _total;

        public IReadOnlyList<SalesLineItem> LineItems => _lineItems;

        public bool IsComplete
        {
            get => _isComplete;
            set => _isComplete = value;
        }

        public Payment Payment
        {
            get => _payment;
            set => _payment = value;
        }

        public double Balance => _payment.Amount - GetTotal();

        public CustomerDescription CustomerDescription => _customerDescription;

        public Sale(CustomerDescription customerDescription, Moms moms)
        {
            _customerDescription = customerDescription;
            _moms = moms;
        }

        public void BecomeComplete()
        {
            _isComplete = true;
        }

        public void MakeLineItem(ProductDescription pdesc, int quantity)
        {
            _lineItems.Add(new SalesLineItem(pdesc, quantity));
        }

        public double GetTotal()
        {
            double total = 0;

            for (int i = 0; i < _lineItems.Count; i++)
            {
                total += _lineItems[i].GetSubtotal();
            }

            return total;
        }

        public double GetTotalWithDiscount()
        {
            return GetTotal() - (GetTotal() * _customerDescription.Rabatsats); ;
        }

        public double GetMoms()
        {
            return _moms.CalculateMoms(GetTotalWithDiscount());
        }

        public double GetDiscountAmount()
        {
            return GetTotal() * _customerDescription.Rabatsats;
        }

        public double GetTotalWithMoms()
        {
            return GetTotal() + _moms.CalculateMoms(GetTotal());
        }

        public void MakePayment(double cashTendered)
        {
            _payment = new Payment(cashTendered);
        }
    }
}