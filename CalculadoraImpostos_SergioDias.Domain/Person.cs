namespace CalculadoraImpostos_SergioDias.Domain
{
    public class Person
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Tax { get; set; }
    }
}
