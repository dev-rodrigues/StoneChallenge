using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Service
{
    public class MonthService
    {
        public static string GetMonth(int month)
        {
            string monthRef = "";

            switch (month)
            {
                case 1:
                    monthRef = "JANEIRO";
                    break;

                case 2:
                    monthRef = "FEVEREIRO";
                    break;

                case 3:
                    monthRef = "MARÇO";
                    break;

                case 4:
                    monthRef = "ABRIL";
                    break;

                case 5:
                    monthRef = "MAIO";
                    break;

                case 6:
                    monthRef = "JUNHO";
                    break;

                case 7:
                    monthRef = "JULHO";
                    break;

                case 8:
                    monthRef = "AGOSTO";
                    break;

                case 9:
                    monthRef = "SETEMBRO";
                    break;

                case 10:
                    monthRef = "OUTUBRO";
                    break;

                case 11:
                    monthRef = "NOVEMBRO";
                    break;

                case 12:
                    monthRef = "DEZEMBRO";
                    break;
            }

            return monthRef;
        }
    }
}
