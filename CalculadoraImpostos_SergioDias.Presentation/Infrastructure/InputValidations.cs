namespace CalculadoraImpostos_SergioDias.Presentation.Infrastructure
{
    public static class InputValidations
    {
        public static bool ValidateConsoleNotEmpty(string input)
        {
            return !string.IsNullOrEmpty(input);
        }
        public static bool ValidatePositiveDecimal(string input)
        {
            if (ValidateConsoleNotEmpty(input))
            {
                decimal convertedValue;
                return decimal.TryParse(input, out convertedValue) && convertedValue > 0;
            }
            return false;
        }
        //public static bool ValidateCpf(string cpf)
        //{
        //    Regex RgxCpf = new(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$");
        //    return RgxCpf.Match(cpf).Success;
        //}
    }
}
