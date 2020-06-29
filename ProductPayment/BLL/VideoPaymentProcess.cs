using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductPayment.Models;

namespace ProductPayment.BLL
{
    public class VideoPaymentProcess : IProcessPayment
    {
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
                    Payment payment = new Payment();
                    payment.OrderId = order.OrderId;
                    payment.PaymentAmount = amount;
                    payment.PaymentDate = DateTime.UtcNow;

                    // insert payment details to the database;

                    // processEmail
                    string emailid = order.CustomerObj.EmailId;
                    string emailBody = ""; // bring from config or db or resource file for standard text.
                                           // create email object and send an email with Video link to "Learning to Ski" and link to "First Aid"

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
