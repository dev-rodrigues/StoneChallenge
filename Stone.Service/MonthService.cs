using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Service
{
    public class MonthService
    {
        public static string GetMonth(int mes)
        {
            string mesReferencia = "";

            switch (mes)
            {
                case 1:
                    mesReferencia = "JANEIRO";
                    break;

                case 2:
                    mesReferencia = "FEVEREIRO";
                    break;

                case 3:
                    mesReferencia = "MARÇO";
                    break;

                case 4:
                    mesReferencia = "ABRIL";
                    break;

                case 5:
                    mesReferencia = "MAIO";
                    break;

                case 6:
                    mesReferencia = "JUNHO";
                    break;

                case 7:
                    mesReferencia = "JULHO";
                    break;

                case 8:
                    mesReferencia = "AGOSTO";
                    break;

                case 9:
                    mesReferencia = "SETEMBRO";
                    break;

                case 10:
                    mesReferencia = "OUTUBRO";
                    break;

                case 11:
                    mesReferencia = "NOVEMBRO";
                    break;

                case 12:
                    mesReferencia = "DEZEMBRO";
                    break;
            }

            return mesReferencia;
        }
    }
}
