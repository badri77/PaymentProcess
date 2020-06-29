using ProductPayment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPayment.BLL
{
    public class GeneratePackageSlip
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
    }
}
