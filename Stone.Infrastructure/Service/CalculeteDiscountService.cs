using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Service
{
    public class CalculeteDiscountService
    {
        private static decimal VALOR_MINIMO = 1500.00m;

        public static decimal CalculeteIrpf(decimal alicota, decimal deducion, decimal salary)
        {

            decimal imposto = 0;

            // contribuinte nao paga imposto
            if (alicota == 0 && deducion == 0)
            {
                return imposto;
            }

            imposto = ((alicota / 100) * salary);
            imposto = imposto - deducion;
            return Decimal.Round(imposto, 2);
        }

        public static decimal CalculeteInss(decimal alicota, decimal salary)
        {
            decimal imposto = ((alicota / 100) * salary);
            return Decimal.Round(imposto, 2);
        }

        public static decimal CacluleTransport(decimal salary)
        {
            decimal desconto = 0;
            if (salary < VALOR_MINIMO)
            {
                return desconto;
            }

            desconto = (decimal)0.06 * salary;

            return Decimal.Round(desconto, 2);
        }

        public static decimal CacluleFGTS(decimal salary)
        {
            decimal desconto = 0;
            if (salary < VALOR_MINIMO)
            {
                return desconto;
            }

            desconto = (decimal)0.08 * salary;

            return Decimal.Round(desconto, 2);
        }
    }
}
