using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Service
{
    public class CalculeteDiscountService
    {

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
            return Decimal.Round(imposto);
        }

        public static decimal CalculeteInss(decimal alicota, decimal salary)
        {
            decimal imposto = ((alicota / 100) * salary);
            return Decimal.Round(imposto);
        }
    }
}
