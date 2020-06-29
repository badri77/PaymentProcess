using ProductPayment.Models;
using System;

namespace ProductPayment.BLL
{
    public class UpgradeMembershipPaymentProcess : IProcessPayment
    {

        IMembershipProcess _membershipProcess = new MembershipProcess();
        
        public string PaymentProcess(Order order, double amount)
        {
            try
            {
                // do payment process with amout.

                string result = _membershipProcess.ProcessMembershipRequest(order, amount);
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
        
    }
}
