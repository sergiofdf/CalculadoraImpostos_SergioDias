using CalculadoraImpostos_SergioDias.Domain;
using ConsoleTables;

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
                var defaultForegroundColor = Console.ForegroundColor;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(errorMessage);
                Console.BackgroundColor = defaultBackgroundColor;
                Console.ForegroundColor = defaultForegroundColor;
            }
            return Console.ReadLine().Trim().Replace(".", "").Replace("-", "");
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

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        public static void DisplayPerson(Person person)
        {
            var table = new ConsoleTable("CPF", "Nome", "Total Recebido", "Imposto a Pagar");
            table.AddRow(person.Cpf, person.Name, $"R$ { string.Format("{0:0.00}", person.TotalValue)}", $"R$ { string.Format("{0:0.00}", person.Tax)}");
            table.Write();
            Console.WriteLine();
        }
        public static void DisplayPersonList(List<Person> people)
        {
            var table = new ConsoleTable("CPF", "Nome", "Total Recebido", "Imposto a Pagar");
            foreach (var person in people)
            {
                table.AddRow(person.Cpf, person.Name, $"R$ { string.Format("{0:0.00}", person.TotalValue)}", $"R$ { string.Format("{0:0.00}", person.Tax)}");
            }
            table.Write();
            Console.WriteLine();
        }
    }
}
