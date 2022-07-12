using CalculadoraImpostos_SergioDias.Domain;

namespace CalculadoraImpostos_SergioDias.Repositories.Interfaces
{
    public interface IPersonTaxInfoRepository
    {
        public void SavePerson(Person person);
        public Person GetPersonByCpf(string cpf);
        public List<Person> ListAllRegister();
    }
}
