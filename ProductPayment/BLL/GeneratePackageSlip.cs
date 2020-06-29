using ProductPayment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPayment.BLL
{
    public interface IGeneratePackageSlip
    {
        string GeneratePackingSlip(Order order);
        double ProcessCommission(Payment payment);
    }
    public class GeneratePackageSlip : IGeneratePackageSlip
    {
        public String GeneratePackingSlip(Order order)
        {
            
            string addressSlip = string.Empty;
            
            if (order != null)
            {
                addressSlip = $@" Order Details : {order.OrderId.ToString() + order.OrderDate}
                                 CustomerName :  {order.CustomerObj.CustomerName}
                                 CustomerAddress: { order.CustomerObj.AddressLine1}
                                                    { order.CustomerObj.City}  ";

                
            }
            return addressSlip;
        }

        public  double ProcessCommission(Payment payment)
        {
            double commissionPercentage = 10;
            double CommisionAmount;
            // get percentage value for each product type
            // commissionPercentage = repository.GetPercentage4ProductType(productType);
            CommisionAmount = (payment.PaymentAmount * commissionPercentage) / 100;

            // save the value for the commission agent payment  repository
            // agent = new CommissionAgent(id);
            // agent.addCommision(CommissionAmount);

            return CommisionAmount;

        }
    }
}
