using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductPayment.Models;

namespace ProductPayment.BLL
{
    public class MemberPaymentProcess : IProcessPayment
    {
        MembershipProcess _membershipProcess = new MembershipProcess();
        //public MemberPaymentProcess(MembershipProcess membershipProcess)
        //{
        //    _membershipProcess = membershipProcess;
        //}
        public string PaymentProcess(Order order, double amount)
        {
            try
            {
                // do payment process with amout.

                string result = _membershipProcess.ProcessMembershipRequest(order);

                Console.WriteLine("The Membership process result {0}", result);

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
