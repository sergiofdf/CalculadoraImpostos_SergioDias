namespace CalculadoraImpostos_SergioDias.Presentation.Presentations
{
    public static class Messages
    {
        public const string valueInput = "Digite o valor total faturado durante o ano.";
        public const string valueInputError = "Valor inválido. Digite um valor positivo e utilize vírgula como separador decimal.";
        public static string ScreenTaxToPay(decimal value)
        {
            return $"O valor total a pagar será de R$ {string.Format("{0:0.00}", value)}";
        }
    }
}
