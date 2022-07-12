using CalculadoraImpostos_SergioDias.Domain;
using CalculadoraImpostos_SergioDias.Repositories.Interfaces;

namespace CalculadoraImpostos_SergioDias.Services
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly IPersonTaxInfoRepository _repository;
        public TaxCalculator(IPersonTaxInfoRepository repository)
        {
            _repository = repository;
        }

        public decimal TaxCalculation(decimal totalRevenue)
        {
            decimal aliquot = 0;
            decimal deduction = 0;
            if (totalRevenue <= 22847.76m)
            {
                aliquot = decimal.Zero;
                deduction = decimal.Zero;
            }
            else if (totalRevenue > 22847.76m && totalRevenue <= 33919.80m)
            {
                aliquot = 0.075m;
                deduction = 1713.58m;
            }
            else if (totalRevenue > 33919.80m && totalRevenue <= 45012.60m)
            {
                aliquot = 0.150m;
                deduction = 4257.57m;
            }
            else if (totalRevenue > 45012.60m && totalRevenue <= 55976.16m)
            {
                aliquot = 0.225m;
                deduction = 7633.51m;
            }
            else if (totalRevenue > 55976.16m)
            {
                aliquot = 0.275m;
                deduction = 10432.32m;
            }

            return totalRevenue * aliquot - deduction;
        }

        public List<Person> ListTaxInfo()
        {
            return _repository.ListAllRegister();
        }

        public bool RegisterTaxValue(Person person)
        {
            var personSearch = SearchTaxInfo(person.Cpf);
            if (personSearch != null)
                return false;
            person.Tax = TaxCalculation(person.TotalValue);
            _repository.SavePerson(person);
            return true;
        }

        public Person SearchTaxInfo(string cpf)
        {
            return _repository.GetPersonByCpf(cpf);
        }

    }
}
