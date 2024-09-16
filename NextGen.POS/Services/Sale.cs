using NextGen.POS.Models;

namespace NextGen.POS.Services
{
    public class Sale
    {
        private readonly List<SalesLineItem> _lineItems = new List<SalesLineItem>();
        private bool _isComplete = false;
        private Payment _payment;
        private readonly CustomerDescription _customerDescription;
        private readonly Moms _moms;
        private double? _total = null;

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

        public double Balance => _payment.Amount - GetTotalWithMoms();

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
            _total = null; // Reset total
        }

        public double GetTotal()
        {
            if (_total == null)
            {
                double total = 0;
                for (int i = 0; i < _lineItems.Count; i++)
                {
                    total += _lineItems[i].GetSubtotal();
                }
                _total = total;
            }
            return _total.Value;
        }

        public double GetTotalWithDiscount()
        {
            double totalWithDiscount = GetTotal() * (1 - _customerDescription.Rabatsats);
            return totalWithDiscount >= 0 ? totalWithDiscount : 0; // Return 0 if totalWithDiscount is negative
        }

        public double GetMoms()
        {
            return _moms.CalculateMoms(GetTotalWithDiscount());
        }

        public double GetDiscountAmount()
        {
            double discountAmount = GetTotal() * _customerDescription.Rabatsats;
            return discountAmount >= 0 ? discountAmount : 0; // Return 0 if discountAmount is negative
        }

        public double GetTotalWithMoms()
        {
            return _moms.CalculateTotalWithMoms(GetTotal());
        }

        public void MakePayment(double cashTendered)
        {
            _payment = new Payment(cashTendered);
        }
    }
}
