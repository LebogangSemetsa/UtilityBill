

using System.Globalization;
using System.Transactions;
using System.Xml.Linq;
using UtilityBill;

public class myUtilityBill
{
  
    public static void Main()
    {
        string inputPassword ;
        string inputUsername ;
        string NEWUsername;
        string NEWPassword;

        string Fname ;
        string Lname ;
        string PloT;
        string locatioN ;
        double UsedByCustomer ;
        string typeOfCustomer ;

        ClassOfMethods CuStomer1 = new ClassOfMethods ();
        ClassOfMethods CuStomer2 = new ClassOfMethods();

        beginApp:
        Console.Clear();
        Console.WriteLine("Hello!");
        Console.WriteLine("Choose an Option Below");
        Console.WriteLine("a.__Login using an exsistig account");
        Console.WriteLine("b.__Create an account ");
        Console.WriteLine("c.__Exit Application");

    string initialInput = Console.ReadLine();

        if (initialInput == "a")
        {
            Console.Clear();
            Console.WriteLine("You indicated to have an account, please enter any key to begin login.");
            Console.ReadKey();
        }

        else if (initialInput == "b")
        {
            Console.Clear();
            Console.WriteLine("<<<<<<CREATING USERNAME AND PASSWORD>>>>>>");

            Console.WriteLine("Hello Customer, Please Enter Username and Password  below.");
            Console.Write("Username : -");
            NEWUsername = Console.ReadLine();
            Console.Write("Password : -");
            NEWPassword = Console.ReadLine();
            Console.Clear();


            if (CuStomer1.Cust_FirstName == " ")
            {
                CuStomer1.Cust_UserName = NEWUsername;
                CuStomer1.Cust_Password = NEWPassword;

                var MyDetails = Customer_Info.GetCustomerDetails();
                Fname = MyDetails.Item1;
                Lname = MyDetails.Item2;
                PloT = MyDetails.Item3;
                locatioN = MyDetails.Item4;
                typeOfCustomer = MyDetails.Item5;

                CuStomer1.Cust_FirstName = Fname;
                CuStomer1.Cust_Lastname = Lname;
                CuStomer1.Cust_PlotNumber = PloT;
                CuStomer1.Cust_Location = locatioN;
                CuStomer1.Cust_Type = typeOfCustomer;


            }
            else if (CuStomer2.Cust_FirstName == " ")
            {
                CuStomer2.Cust_UserName = NEWUsername;
                CuStomer2.Cust_Password = NEWPassword;

                var MyDetails = Customer_Info.GetCustomerDetails();
                Fname = MyDetails.Item1;
                Lname = MyDetails.Item2;
                PloT = MyDetails.Item3;
                locatioN = MyDetails.Item4;
                typeOfCustomer = MyDetails.Item5;



                CuStomer2.Cust_FirstName = Fname;
                CuStomer2.Cust_Lastname = Lname;
                CuStomer2.Cust_PlotNumber = PloT;
                CuStomer2.Cust_Location = locatioN;
                CuStomer2.Cust_Type = typeOfCustomer;
            }
            else
            {
                Console.WriteLine(" Can not store another user");
                goto beginApp;
            }
        }
        else if (initialInput == "c")
            goto endApp;

        else
        {
            Console.WriteLine("Invalid input");
            Console.ReadKey();
            goto beginApp;
        }

        var CollectedInitials = Customer_Info.AccountValidate(CuStomer1.Cust_UserName , CuStomer1.Cust_Password , CuStomer2.Cust_UserName , CuStomer2.Cust_Password);
        inputUsername = CollectedInitials.Item1;
        inputPassword = CollectedInitials.Item2;

        Console.WriteLine("             Press any key To Begin Operation    ");
        Console.ReadKey();
        Console.Clear();


        bool spotCustomer1 = inputPassword == CuStomer1.Cust_Password && inputUsername == CuStomer1.Cust_UserName;
        bool spotCustomer2 = inputPassword == CuStomer2.Cust_Password && inputUsername == CuStomer2.Cust_UserName;

        Console.Clear();
        if (spotCustomer1 == true)
        {
            Console.Write(" Enter total WaterUsed : -");
            CuStomer1.AmountUsed = Convert.ToDouble(Console.ReadLine());
            Console.Clear();
            ClassOfMethods.GenerateBill(CuStomer1.Cust_FirstName, CuStomer1.Cust_Lastname, CuStomer1.Cust_PlotNumber, CuStomer1.Cust_Location, CuStomer1.Cust_Type, CuStomer1.AmountUsed);

        }
        else if (spotCustomer2 == true)
        {
            Console.Write(" Enter total WaterUsed : -");
            CuStomer2.AmountUsed = Convert.ToDouble(Console.ReadLine());
            ClassOfMethods.GenerateBill(CuStomer2.Cust_FirstName, CuStomer2.Cust_Lastname, CuStomer2.Cust_PlotNumber, CuStomer2.Cust_Location, CuStomer2.Cust_Type, CuStomer2.AmountUsed);
        }
        else
        {
            Console.WriteLine("INVALID VALIDATIONS !!!");
        }
        Console.ReadKey();
        Console.Clear();
        goto beginApp;
        endApp:;

    }
}