using CalculadoraImpostos_SergioDias.Domain;
using CalculadoraImpostos_SergioDias.Presentation.Infrastructure;
using CalculadoraImpostos_SergioDias.Presentation.Presentations;
using CalculadoraImpostos_SergioDias.Services;

namespace CalculadoraImpostos_SergioDias.Presentation.ProgramFlow
{
    public class MainFlow : IMainFlow
    {
        private readonly ITaxCalculator _service;

        public MainFlow(ITaxCalculator service)
        {
            _service = service;
        }
        public void BeginApp()
        {
            NavigateMenu();
        }
        public void NavigateMenu()
        {
            var selectedMenu = ScreenPresenter.GetOption(
                Menu.InitialMenu, 1, 5);
            switch (selectedMenu)
            {
                case 1:
                    TaxSimpleCalculation();
                    break;
                case 2:
                    TaxRegistration();
                    break;
                case 3:
                    TaxConsultByCpf();
                    break;
                case 4:
                    ShowAllRegister();
                    break;
                case 5:
                    Quit();
                    break;
            }
            ScreenPresenter.DisplayMessage(Messages.pressKeyContinue);
            Console.ReadKey();
            BeginApp();
        }

        public double TaxSimpleCalculation()
        {
            double value = Convert.ToDouble(ScreenPresenter.GetInput(Messages.valueInput, InputValidations.ValidatePositiveNumber, Messages.valueInputError));

            double taxValue = _service.TaxCalculation(value);
            ScreenPresenter.DisplayMessage(Messages.ScreenTaxToPay(taxValue));
            return taxValue;
        }
        public void TaxRegistration()
        {
            Person person = new();
            person.Name = ScreenPresenter.GetInput(Messages.nameInput, InputValidations.ValidateConsoleNotEmpty, Messages.nameInputError);
            person.Cpf = ScreenPresenter.GetInput(Messages.cpfInput, InputValidations.ValidateConsoleNotEmpty, Messages.cpfInputError).Replace(".", "").Replace("-", "");
            person.TotalValue = Convert.ToDouble(ScreenPresenter.GetInput(Messages.valueInput, InputValidations.ValidatePositiveNumber, Messages.valueInputError));
            person.Tax = _service.TaxCalculation(person.TotalValue);
            ScreenPresenter.DisplayMessage(Messages.ScreenTaxToPay(person.Tax));

            if (!_service.RegisterTaxValue(person))
            {
                ScreenPresenter.DisplayMessage(Messages.personAlreadyExists);
                return;
            }
            _service.RegisterTaxValue(person);
        }
        public void TaxConsultByCpf()
        {
            string cpf = ScreenPresenter.GetInput(Messages.cpfInput, InputValidations.ValidateConsoleNotEmpty, Messages.cpfInputError).Replace(".", "").Replace("-", "");
            var personSearchedByCpf = _service.SearchTaxInfo(cpf);
            if (personSearchedByCpf != null)
            {
                ScreenPresenter.DisplayPerson(personSearchedByCpf);
            }
        }
        public void ShowAllRegister()
        {
            List<Person> lista = _service.ListTaxInfo();
            ScreenPresenter.DisplayPersonList(lista);
        }
        public void Quit()
        {
            Environment.Exit(0);
        }
    }
}
