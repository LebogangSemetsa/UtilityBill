using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityBill
{
    public class Tariffs


    {

        public static (double, double) GetDomesticUser(double amount_Used)
        {
            double Portable_Calculated = 0;
            double Waste_Calculated = 0;


            if (amount_Used >= 0 && amount_Used <= 5)
            {
                Portable_Calculated = 5 * 3.60;
                Waste_Calculated = 5 * 0.65;
            }

            else if (amount_Used >= 6 && amount_Used <= 15)
            {
                Portable_Calculated = (5 * 3.60) + ((amount_Used - 5) * 11.78);
                Waste_Calculated = (5 * 0.65) + ((amount_Used - 5) * 2.95);
            }
            else if (amount_Used >= 16 && amount_Used <= 25)
            {
                Portable_Calculated = (5 * 3.60) + (10 * 11.78) + ((amount_Used - 15) * 20.62);
                Waste_Calculated = (5 * 0.65) + (10 * 2.95) + ((amount_Used - 15) * 4.41);
            }

            else if (amount_Used >= 26 && amount_Used <= 40)
            {
                Portable_Calculated = (5 * 3.60) + (10 * 11.78) + (10 * 20.62) + ((amount_Used - 24) * 31.72);
                Waste_Calculated = (5 * 0.65) + (10 * 2.95) + (10 * 4.41) + ((amount_Used - 24) * 5.89);
            }
            else if (amount_Used > 41)
            {
                Portable_Calculated = (5 * 3.60) + (10 * 11.78) + (10 * 20.62) + (15 * 31.72) + ((amount_Used - 40) * 39.66);
                Waste_Calculated = (5 * 0.65) + (10 * 2.95) + (10 * 4.41) + (15 * 5.89) + ((amount_Used - 40) * 7.36);
            }
            else
            {
                Console.WriteLine(" Error INPUTS");
            }
 
            return (Portable_Calculated, Waste_Calculated);
        }


        public static (double, double) GetCommercialUser(double amount_Used)
        {
            double Portable_Calculated = 0;
            double Waste_Calculated = 0;


            if (amount_Used >= 0 && amount_Used <= 5)
            {
                Portable_Calculated = 5 * 4.32;
                Waste_Calculated = 5 * 0.65;
            }

            else if (amount_Used >= 6 && amount_Used <= 15)
            {
                Portable_Calculated = (5 * 4.32) + ((amount_Used - 5) * 12.82);
                Waste_Calculated = (5 * 0.65) + ((amount_Used - 5) * 2.95);
            }
            else if (amount_Used >= 16 && amount_Used <= 25)
            {
                Portable_Calculated = (5 * 4.32) + (10 * 12.82) + ((amount_Used - 15) * 22.44);
                Waste_Calculated = (5 * 0.65) + (10 * 2.95) + ((amount_Used - 15) * 4.41);
            }

            else if (amount_Used >= 26 && amount_Used <= 40)
            {
                Portable_Calculated = (5 * 4.32) + (10 * 12.82) + (10 * 22.44) + ((amount_Used - 24) * 34.52);
                Waste_Calculated = (5 * 0.65) + (10 * 2.95) + (10 * 4.41) + ((amount_Used - 24) * 5.89);
            }
            else if (amount_Used > 41)
            {
                Portable_Calculated = (5 * 4.32) + (10 * 12.82) + (10 * 22.44) + (15 * 34.52) + ((amount_Used - 40) * 43.16);
                Waste_Calculated = (5 * 0.65) + (10 * 2.95) + (10 * 4.41) + (15 * 5.89) + ((amount_Used - 40) * 7.36);
            }
            else
            {
                Console.WriteLine(" Error INPUTS");
            }
          
            return (Portable_Calculated, Waste_Calculated);
        }
    }
}
