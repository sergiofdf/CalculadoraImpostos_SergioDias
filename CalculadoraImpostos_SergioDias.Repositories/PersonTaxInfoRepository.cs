using CalculadoraImpostos_SergioDias.Domain;
using CalculadoraImpostos_SergioDias.Repositories.Interfaces;

namespace CalculadoraImpostos_SergioDias.Repositories
{
    public class PersonTaxInfoRepository : IPersonTaxInfoRepository
    {
        private readonly IBaseRepository<Person> _database;
        public List<Person> People { get; set; }

        public PersonTaxInfoRepository(IBaseRepository<Person> database)
        {
            _database = database;
            var values = _database.Get();
            if (values != null)
                People = values.ToList();
            else
                People = new();
        }
        public void SavePerson(Person person)
        {
            People.Add(person);
        }

        public Person GetPersonByCpf(string cpf)
        {
            var personSearch = People.First(p => p.Cpf == cpf);
            return personSearch;
        }

        public List<Person> ListAllRegister()
        {
            return People;
        }
    }
}
