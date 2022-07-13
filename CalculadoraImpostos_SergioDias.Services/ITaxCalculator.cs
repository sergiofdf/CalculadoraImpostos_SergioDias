using CalculadoraImpostos_SergioDias.Domain;

namespace CalculadoraImpostos_SergioDias.Services
{
    public interface ITaxCalculator
    {
        public double TaxCalculation(double totalRevenue);
        public bool RegisterTaxValue(Person person);
        public Person SearchTaxInfo(string cpf);
        public List<Person> ListTaxInfo();
    }
}
