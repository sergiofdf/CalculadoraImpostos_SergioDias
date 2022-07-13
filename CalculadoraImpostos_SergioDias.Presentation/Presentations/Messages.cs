namespace CalculadoraImpostos_SergioDias.Presentation.Presentations
{
    public static class Messages
    {
        public const string nameInput = "Digite o nome";
        public const string nameInputError = "Não é aceito campo vazio";
        public const string cpfInput = "Digite o cpf";
        public const string cpfInputError = "Digite no formato 123.123.123-12";
        public const string valueInput = "Digite o valor total de rendimentos tributáveis recebido durante o ano.";
        public const string valueInputError = "Valor inválido. Digite um valor positivo e utilize vírgula como separador decimal.";
        public const string personAlreadyExists = "\nEssa pessoa já está cadastrada.";
        public const string pressKeyContinue = "\nPressione qualquer tecla para continuar...";
        public static string ScreenTaxToPay(double value)
        {
            return $"\nO valor total a pagar será de R$ {string.Format("{0:0.00}", value)}";
        }
    }
}
