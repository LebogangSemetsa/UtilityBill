using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace UtilityBill
{
    public class ClassOfMethods
    {

        public string Cust_FirstName;
        public string Cust_Lastname;
        public string Cust_Location;
        public string Cust_Type;
        public string Cust_UserName;
        public string Cust_Password;
        public string Cust_PlotNumber;
        public double AmountUsed;

        public ClassOfMethods()
        {
            Cust_FirstName = " ";
            Cust_Lastname = " ";
            Cust_Location = " ";
            Cust_PlotNumber = " ";
            Cust_UserName = " ";
            Cust_Password = " ";
            Cust_Type = "Non";
            AmountUsed = 0;
        }


         static double Calc_VAT(double bill_amount, double Used_water_By_Customer_in_Kl)
        {
           
            double VAT;
            if (Used_water_By_Customer_in_Kl <= 5)
            {
                VAT = 0;
            }
            
            else
            {
                VAT = bill_amount * 0.14;
            }
            
            return VAT;
         }

       public static void  GenerateBill (string firstName,string  lastName,string plotNumber,string locatioN,string customerType,double amountOfUsedWater)
        {

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(" Firstname      : " + firstName + "     Lastname : " + lastName);
            Console.WriteLine(" Plot Number    : " + plotNumber);
            Console.WriteLine(" Location       : " + locatioN);
            Console.WriteLine(" User Type      : " + customerType);
            Console.WriteLine(" ");
            Console.WriteLine(" Amount Used(Kl): " + amountOfUsedWater);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(" Press enter To confirm Above Input and Generate Bill");
            Console.ReadLine();
            Console.Clear();


            double D_portal = 0;
            double D_waste = 0;
            double VAT1 = 0;
            double billtotal = 0;

            if (customerType == "Domestic")
            {
                var Hold_Domestic_Portal_and_Waste = Tariffs.GetDomesticUser(amountOfUsedWater);

                D_portal = Hold_Domestic_Portal_and_Waste.Item1;
                D_waste = Hold_Domestic_Portal_and_Waste.Item2;
                double Totals = D_waste + D_portal;
                VAT1 = Calc_VAT(Totals, amountOfUsedWater);

                billtotal = Totals + VAT1;
            }


            else if (customerType == "Commercial")
            {
                var Hold_Commecial_Portable_and_Waste = Tariffs.GetCommercialUser(amountOfUsedWater);

                D_portal = Hold_Commecial_Portable_and_Waste.Item1;
                D_waste = Hold_Commecial_Portable_and_Waste.Item2;

                double Totals = D_waste + D_portal;
                VAT1 = Calc_VAT(Totals, amountOfUsedWater);

                billtotal = Totals + VAT1;


            }
            else
            {
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("                               ERROR INPUTS! DOMESTIC OR BUSINESS  ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            }



            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("                                         Monthly bill ");
            Console.WriteLine(" ");
            Console.WriteLine(" Names      : " + firstName + " " + lastName + "    Location : " + locatioN +"   Plot : "+plotNumber + "          Customer Type : " + customerType);
            Console.WriteLine(" ");
            Console.WriteLine(" Water used : " + amountOfUsedWater + "Kl");
            Console.WriteLine(" ");
            Console.WriteLine(" Portable Water used : " + (D_portal.ToString("n2")));
            Console.WriteLine(" Waste Water Cost    : " + (D_waste.ToString("n2")));
            Console.WriteLine(" ");
            Console.WriteLine(" VAT        : " + (VAT1.ToString("n2")));
            Console.WriteLine(" ");
            Console.WriteLine(" Total      : " + (billtotal.ToString("n2")));
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            using (TextWriter writer = File.CreateText("LebogangOUTPUT.txt"))
            {

                writer.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                writer.WriteLine("                                         Monthly bill ");
                writer.WriteLine(" ");
                writer.WriteLine(" Names      : " + firstName + " " + lastName + "    Location : " + locatioN + "   Plot : " + plotNumber + "          Customer Type : " + customerType);
                writer.WriteLine(" ");
                writer.WriteLine(" Water used : " + amountOfUsedWater + "Kl");
                writer.WriteLine(" ");
                writer.WriteLine(" Portable Water used : " + (D_portal.ToString("n2"))); //console.writeline(value.Tostring("n2"));
                writer.WriteLine(" Waste Water Cost    : " + (D_waste.ToString("n2")));
                writer.WriteLine(" ");
                writer.WriteLine(" VAT        : " + (VAT1.ToString("n2")));
                writer.WriteLine(" ");
                writer.WriteLine(" Total      : " + (billtotal.ToString("n2")));
                writer.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            }
           

        }
public static (string,string ) Login()
            {
            string myUsername;
            string myPassword;

            Console.WriteLine("----------------------LOGIN-SCREEN--------------------");

            Console.WriteLine("Hello Customer, Please Enter Username and Password  below.");
            Console.Write("Username : -");
            myUsername = Console.ReadLine();
            Console.Write("Password : -");
            myPassword = Console.ReadLine();
            Console.Clear();
            return (myUsername,myPassword);
        }



    }
}
