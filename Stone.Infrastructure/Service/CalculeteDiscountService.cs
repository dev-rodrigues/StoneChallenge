using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Service
{
    public class CalculeteDiscountService
    {
        private const decimal SALARIO_MINIMO_PARA_TRANSPORTE = 1500.00m;

        public static decimal CalculeteIrpf(decimal alicota, decimal deducion, decimal salary)
        {            
            // contribuinte nao paga imposto
            if (alicota == 0 && deducion == 0)
            {
                return (decimal)0.0;
            }

            decimal imposto = ((alicota / 100) * salary);
            imposto = imposto - deducion;
            return Decimal.Round(imposto, 2);
        }

        public static decimal CalcularInss(decimal aliquota, decimal salario)
        {
            decimal imposto = ((aliquota / 100) * salario);
            return Decimal.Round(imposto, 2);
        }

        public static decimal CalcularTransporte(decimal salario)
        {
            decimal desconto = 0;
            if (salario < SALARIO_MINIMO_PARA_TRANSPORTE)
            {
                return (decimal)0.0;
            }

            desconto = (decimal)0.06 * salario;

            return Decimal.Round(desconto, 2);
        }

        public static decimal CalcularFgts(decimal salario)
        {
            decimal descontoFgts = (decimal)0.08 * salario;
            return Decimal.Round(descontoFgts, 2);
        }
    }
}
