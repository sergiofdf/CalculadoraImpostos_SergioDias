using CalculadoraImpostos_SergioDias.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace CalculadoraImpostos_SergioDias.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public BaseRepository()
        {
        }

        public void Save(IEnumerable<T> values)
        {
            var name = $"{typeof(T).Name}.txt";

            if (!File.Exists(name))
            {
                using var fs = File.Create(name);
            }

            var jsonStr = JsonConvert.SerializeObject(values);

            using (var file = File.Open(name, FileMode.OpenOrCreate))
            {
                byte[] dados = new UTF8Encoding(true).GetBytes(jsonStr);
                file.Write(dados, 0, dados.Length);

                file.Flush();
            }
        }

        public IEnumerable<T> Get()
        {
            IEnumerable<T> response = default;
            var name = $"{typeof(T).Name}.txt";

            if (File.Exists(name))
            {
                var fileStr = File.ReadAllText(name);

                if (!string.IsNullOrWhiteSpace(fileStr))
                    response = JsonConvert.DeserializeObject<IEnumerable<T>>(fileStr);
            }

            return response;
        }
    }
}

