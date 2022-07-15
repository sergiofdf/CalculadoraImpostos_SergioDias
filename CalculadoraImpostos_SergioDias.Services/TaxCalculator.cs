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
            TaxTiersTable taxTiersTable = new TaxTiersTable();
            taxTiersTable.SetParametersForTier(totalRevenue);
            double aliquot = taxTiersTable.Aliquot;
            double deduction = taxTiersTable.Deduction;
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
