namespace CalculadoraImpostos_SergioDias.Domain
{
    public class TaxTiersTable
    {
        public double Aliquot { get; private set; }
        public double Deduction { get; private set; }

        public void SetParametersForTier(double totalRevenue)
        {
            if (totalRevenue <= 22847.76)
            {
                Aliquot = 0;
                Deduction = 0;
            }
            else if (totalRevenue > 22847.76 && totalRevenue <= 33919.80)
            {
                Aliquot = 0.075;
                Deduction = 1713.58;
            }
            else if (totalRevenue > 33919.8 && totalRevenue <= 45012.6)
            {
                Aliquot = 0.15;
                Deduction = 4257.57;
            }
            else if (totalRevenue > 45012.60 && totalRevenue <= 55976.16)
            {
                Aliquot = 0.225;
                Deduction = 7633.51;
            }
            else if (totalRevenue > 55976.16)
            {
                Aliquot = 0.275;
                Deduction = 10432.32;
            }
        }
    }
}
