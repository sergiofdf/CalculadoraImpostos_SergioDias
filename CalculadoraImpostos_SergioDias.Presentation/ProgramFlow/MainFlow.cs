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
                Menu.InitialMenu, 1, 4);
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
                    Quit();
                    break;
            }
        }

        public void TaxSimpleCalculation()
        {
            decimal value = Convert.ToDecimal(ScreenPresenter.GetInput(Messages.valueInput, InputValidations.ValidatePositiveDecimal, Messages.valueInputError));

            decimal taxValue = _service.TaxCalculation(value);
            ScreenPresenter.DisplayMessage(Messages.ScreenTaxToPay(taxValue));
        }
        public void TaxRegistration() { }
        public void TaxConsultByCpf() { }
        public void Quit() { }
    }
}
