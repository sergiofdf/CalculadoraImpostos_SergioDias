namespace CalculadoraImpostos_SergioDias.Presentation.Infrastructure
{
    public static class ScreenPresenter
    {
        public static string Show(string screen, string errorMessage = "")
        {
            Console.Clear();
            Console.WriteLine(screen);

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                Console.WriteLine();
                var defaultBackgroundColor = Console.BackgroundColor;
                var defaultForegroundColor = Console.BackgroundColor;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(errorMessage);
                Console.BackgroundColor = defaultBackgroundColor;
                Console.ForegroundColor = defaultForegroundColor;
            }
            return Console.ReadLine().Trim();
        }
        public static int GetOption(
            string screen,
            int initialMenu,
            int endMenu,
            string customMessage = null)
        {
            int response;
            var messages = string.Empty;

            while (!int.TryParse(Show(screen, messages), out response) ||
                !(response >= initialMenu && response <= endMenu))
                messages = customMessage ?? "Opção Inválida";

            return response;
        }

        public static string GetInput(
            string screen,
            Predicate<string> predicate,
            string customMessage = null)
        {
            string response;
            var messages = string.Empty;

            while (!predicate.Invoke(response = Show(screen, messages)))
                messages = customMessage ?? "Opção Inválida";

            return response;
        }
    }
}
