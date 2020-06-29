using ProductPayment.Models;
using System;

namespace ProductPayment.BLL
{

    public interface IMembershipProcess
    {
        string ProcessMembershipRequest(Order order, double amount);
    }
    public class MembershipProcess : IMembershipProcess
    {
        public string ProcessMembershipRequest(Order order, double amount)
        {
            try
            {
                Customer cust = order.CustomerObj;
                bool result = true; // Repository.CheckMembershipforCustomer(cust);
                string retValue;

                if (result && order.ProductObj.Type == ProductType.Upgrade)     // membership already exists.
                {
                    //process payment amount.
                    retValue = "success";// repository.UpgradeMembership(cust);
                    if (!string.IsNullOrWhiteSpace(retValue))
                    {
                        // processEmail
                        string emailid = cust.EmailId;
                        string emailBody = "Membership Upgraded"; // bring from config or db or resource file for standard text.
                                                                  // create email object and send an upgradation email.

                        return "The customer membership has been upgraded successfully";
                    }
                }
                else
                {
                    return "The customer doesn't exists or invalid details.";
                }

                if (result && order.ProductObj.Type == ProductType.Membership)     // new membership.
                {
                    //process payment amount.
                    result = false; // Repository.CheckMembershipforCustomer(cust);.
                    retValue = "success";// repository.CreateMemberShip(cust);
                    if (!string.IsNullOrWhiteSpace(retValue))
                    {
                        // processEmail
                        string emailid = cust.EmailId;
                        string emailBody = "New Membership created and activated"; // bring from config or db or resource file for standard text.
                                                                                   // create email object and send an membership creation and activation email.
                    }
                }
                else
                {
                    return "The customer doesn't exists or invalid details.";
                }

                return "";
            }
            catch (Exception ex)
            {
                // log the error;
                return "";
            }
        }
        //private String CreateMemberShip(Customer customer)
        //{
        //    var value = true; // repository.AddMemberShip(cust);
        //    return "New Membership Added";

        //}

        //private String UpgradeMemberShip(Customer customer)
        //{
        //    var value = true; // repository.UpgradeMembership(cust);
        //    return "Membership Upgraded";
             
        //}
    }
}
