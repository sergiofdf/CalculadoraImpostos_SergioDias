namespace CalculadoraImpostos_SergioDias.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        public void Save(IEnumerable<T> values);
        public IEnumerable<T> Get();
    }
}

