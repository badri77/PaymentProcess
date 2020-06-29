using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductPayment.Models;

namespace ProductPayment.BLL
{
    public class BookPaymentProcess : IProcessPayment
    {
        private Payment payment;
        private readonly GeneratePackageSlip _generatePackageSlip = new GeneratePackageSlip();

        //public BookPaymentProcess(GeneratePackageSlip generatePackageSlip)
        //{
        //    _generatePackageSlip = generatePackageSlip;
        //}
        public string PaymentProcess(Order order, double amount)
        {
            try
            {

                if (order == null || amount <= 0)
                {
                    Console.WriteLine("The Order values are empty Or payment amount is less than Order Amount. Provide Required details to proceed...");
                }
                else if (order.OrderTotalAmount > amount)
                {
                    Console.WriteLine("The payment amount is less than Order Amount. Make full payment");
                }
                else if (order.OrderTotalAmount <= amount)
                {
                    payment = new Payment();
                    payment.OrderId = order.OrderId;
                    payment.PaymentAmount = amount;
                    payment.PaymentDate = DateTime.UtcNow;

                    string packageSlip = _generatePackageSlip.GeneratePackingSlip(order);
                    Console.WriteLine("The package slip : {0} ", packageSlip);
                    Console.WriteLine("The duplicate package slip : {0} ", packageSlip);


                }
                return "success";
            }
            catch (Exception ex)
            {
                //process ex; log the error.
                return "failed";
            }
        }
    }
}
