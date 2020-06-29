using ProductPayment.Models;
using System;

namespace ProductPayment.BLL
{
    public class BookPaymentProcess : IProcessPayment
    {
        
        private readonly IGeneratePackageSlip _generatePackageSlip = new GeneratePackageSlip();

        //public BookPaymentProcess(GeneratePackageSlip generatePackageSlip)
        //{
        //    _generatePackageSlip = generatePackageSlip;
        //}
        public string PaymentProcess(Order order, double amount)
        {
            Payment payment;
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

                    // repository.AddPayment(payment); insert payment details to the database;

                    double commission = _generatePackageSlip.ProcessCommission(payment); // process AGENT commision.
                    Console.WriteLine("The agent commission amount processed  {0}", commission);

                    string packageSlip = _generatePackageSlip.GeneratePackingSlip(order);
                    Console.WriteLine("The package slip : {0} ", packageSlip);
                    Console.WriteLine("The duplicate package slip : {0} ", packageSlip);
                    //if wanted, we can email the address slip
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
