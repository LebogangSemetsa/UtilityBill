using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityBill
{
    public class Customer_Info
    {
        public  static (string ,string , string, string,string) GetCustomerDetails()
        {
            string CustName, CustLastName,PLotNumber,CustomerLocation,CustomerType;

            Console.Write(" Enter your Firstname : -");
            CustName = Console.ReadLine();
            Console.Write(" Enter your LastName : -");
            CustLastName = Console.ReadLine();
            Console.Write(" Enter your PlotNumber : -");
            PLotNumber = Console.ReadLine();
            Console.Write(" Enter your Location : -");
            CustomerLocation = Console.ReadLine();

            int trials = 1;
            CustomerType = " ";

            while ( CustomerType != "a" && CustomerType != "b")
            {

                Console.WriteLine("          ||| Choose your user Type (Lowercase) ||| " + "     Trials: " + trials);
                Console.WriteLine("                     ");
                Console.WriteLine("        a) Domestic                     b) Commercial ");
                Console.Write("                     -");
                CustomerType = Console.ReadLine();
                trials++;
                Console.Clear();
            }
            //============================================================================================
            // (CuStomer1.Cust_FirstName ,CuStomer1.Cust_Lastname, CuStomer1.Cust_PlotNumber, CuStomer1.Cust_Location, CuStomer1.Cust_Type, CuStomer1.AmountUsed
            if (CustomerType == "a")
            {
                CustomerType = "Domestic";
            }

            else if (CustomerType == "b")
            {
                CustomerType = "Commercial";
            }
            else
            {
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("                               ERROR INPUTS IN TYPE OF USER!  ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            }

            return(CustName, CustLastName, PLotNumber, CustomerLocation, CustomerType);

        }

        public static (string ,string )AccountValidate (string Customer1Username , string Customer1Password, string Customer2Username, string Customer2Password)
        {
            bool result= false;
            string inputUsername = "U";
            string inputPassword = "P";

            while (result == false)
            {


             Console.WriteLine("----------------------LOGIN-SCREEN--------------------");

            Console.WriteLine("Hello Customer, Please Enter Username and Password  below.");
            Console.Write("Username : -");
            inputUsername = Console.ReadLine();
            Console.Write("Password : -");
            inputPassword = Console.ReadLine();
            Console.Clear();


            if (inputPassword == Customer1Password && inputUsername == Customer1Username)
            {
                Console.WriteLine("****************      Correct Initials     ***********************");
                Console.WriteLine(" ");
                result = true;
            }
            else if (inputPassword == Customer2Password && inputUsername == Customer2Username)
            {
                Console.WriteLine("****************      Correct Initials     ***********************");
                Console.WriteLine(" ");
                result = true;

                using (StreamWriter Flagz = new StreamWriter("Loggz.txt", true))
                {
                    Flagz.WriteLine(" ");
                    Flagz.WriteLine("[+]  Account of username " + inputUsername + " logged in! " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff"));
                    Flagz.WriteLine(" ");
                }
            }               
                else
            
                {
                result = false;
           
                }
            }
            return (inputUsername, inputPassword);
        }
    }
}
