using ProductPayment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPayment.BLL
{
    public class MembershipProcess
    {


        public string ProcessMembershipRequest(Order order)
        {
            Customer cust = order.CustomerObj;
            var result = true; // Repository.CheckMembershipforCustomer(cust);
            string returnvalue = string.Empty;
            if (result)
            {
                returnvalue = UpgradeMemberShip(cust);
                if (!string.IsNullOrWhiteSpace(returnvalue))
                {
                    // processEmail
                    string emailid = cust.EmailId;
                    string emailBody = ""; // bring from config or db or resource file for standard text.
                    // create email object and send an upgradation email.
                }
            }
            else
            {
                returnvalue =  CreateMemberShip(cust);
                if (!string.IsNullOrWhiteSpace(returnvalue))
                {
                    // processEmail
                    string emailid = cust.EmailId;
                    string emailBody = ""; // bring from config or db or resource file for standard text.
                    // create email object and send an membership creation and activation email.
                }
            }
            return returnvalue;

        }
        private String CreateMemberShip(Customer customer)
        {
            var value = true; // repository.AddMemberShip(cust);
            return "New Membership Added";

            return "";
        }

        private String UpgradeMemberShip(Customer customer)
        {
            var value = true; // repository.UpgradeMembership(cust);
            return "Membership Upgraded";

            return "";
        }
    }
}
