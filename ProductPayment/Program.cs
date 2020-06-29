using ProductPayment.BLL;
using System;

namespace ProductPayment
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Product Payment system...");

            int type;
            string cname, pname;
            double paymentAmount;
            DoProcessPaymentFactory pFactory;

            Console.WriteLine("Enter Product selection value ; (1. Delivarable; 2. Book; 3. New Membership; 4. Upgrade Membership; 5. Video training)");
            type = Convert.ToInt32(Console.ReadLine());
            type = type - 1;
            Console.WriteLine("Enter Product Name : ");
            pname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(pname))
                pname = "The Wings of Fire";
            Console.WriteLine("Enter Customer Name : ");
            cname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(cname))
                pname = "The First Customer";

            Console.WriteLine("Enter Payment Amount : ");
            paymentAmount = Convert.ToDouble(Console.ReadLine());

            pFactory = new DoProcessPaymentFactory();
            string result =pFactory.DoProcess(type, cname, pname, paymentAmount);
            Console.WriteLine("The result of the process :   {0}", result);
            Console.ReadKey();

        }
    }
}

