using ProductPayment.Models;
using System;

namespace ProductPayment.BLL.ProcessPayment
{
    public class UpgradeMembershipPaymentProcess : IProcessPayment
    {

        public string PaymentProcess(Order order, double amount)
        {
            try
            {
                // do payment process with amout.

                string result = ProcessMembershipUpgrade(order, amount);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine("The Membership process result {0}", result);
                    return "success";
                }
                else
                {
                    return "failed";
                }
            }
            catch (Exception ex)
            {
                //process ex; log the error.
                return "failed";
            }
        }

        private string ProcessMembershipUpgrade(Order order, double amount)
        {
            string retValue=string.Empty;
            Customer cust = order.CustomerObj;
            try
            {
                if (order.ProductObj.Type == ProductType.Membership)     // new membership.
                {

                    bool result = false; // Repository.CheckMembershipforCustomer(cust);
                    if (!result)
                    {
                        //process payment amount.
                        var output = amount;
                        retValue = "success";// repository.UpgradeMembership;(cust);
                    }

                    
                    if (!string.IsNullOrWhiteSpace(retValue))
                    {
                        // processEmail
                        string emailid = cust.EmailId;
                        string emailBody = "Membership Upgraded successfully"; // bring from config or db or resource file for standard text.
                                                                                   // create email object and send an membership creation and activation email.
                    }
                    return retValue;
                }
                else
                {
                    return "The customer doesn't exists or invalid details.";
                }
            }
            catch (Exception ex)
            {
                return "failed"; // log the error.
            }
        }

    }
}
