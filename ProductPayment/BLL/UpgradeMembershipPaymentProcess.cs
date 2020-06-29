using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductPayment.Models;

namespace ProductPayment.BLL
{
    public class UpgradeMembershipPaymentProcess : IProcessPayment
    {
        public string PaymentProcess(Order order, double amount)
        {
            try
            {

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
