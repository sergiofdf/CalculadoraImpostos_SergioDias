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

        public double TaxCalculation(double totalRevenue)
        {
            double aliquot = 0;
            double deduction = 0;
            if (totalRevenue <= 22847.76)
            {
                aliquot = 0;
                deduction = 0;
            }
            else if (totalRevenue > 22847.76 && totalRevenue <= 33919.80)
            {
                aliquot = 0.075;
                deduction = 1713.58;
            }
            else if (totalRevenue > 33919.8 && totalRevenue <= 45012.6)
            {
                aliquot = 0.15;
                deduction = 4257.57;
            }
            else if (totalRevenue > 45012.60 && totalRevenue <= 55976.16)
            {
                aliquot = 0.225;
                deduction = 7633.51;
            }
            else if (totalRevenue > 55976.16)
            {
                aliquot = 0.275;
                deduction = 10432.32;
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
            _repository.SavePerson(person);
            return true;
        }

        public Person SearchTaxInfo(string cpf)
        {
            return _repository.GetPersonByCpf(cpf);
        }

    }
}
