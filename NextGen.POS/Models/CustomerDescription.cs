namespace NextGen.POS.Models
{
    public class CustomerDescription
    {
        public int Kundenummer { get; }
        public string Navn { get; }
        public double Rabatsats { get; }

        public CustomerDescription(int kundenummer, string navn, double rabatsats)
        {
            Kundenummer = kundenummer;
            Navn = navn;
            Rabatsats = rabatsats; // 0.25 = 25%
        }
    }
}