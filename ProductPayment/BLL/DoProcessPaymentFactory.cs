using ProductPayment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPayment.BLL
{
    public class DoProcessPaymentFactory
    {
        private IProcessPayment _processPayment;

        private IProcessPayment GetPaymentProcess(int productType)
        {
            switch (productType)
            {
                case 0:
                    _processPayment = new PhysicalProductPaymentProcess();
                    return _processPayment;
                    break;
                case 1:
                    _processPayment = new BookPaymentProcess();
                    return _processPayment;
                    break;
                case 2:
                    _processPayment = new MemberPaymentProcess();
                    return _processPayment;
                    break;
                case 3:
                    _processPayment = new MemberPaymentProcess();
                    return _processPayment;
                    break;
                case 4:
                    _processPayment = new VideoPaymentProcess();
                    return _processPayment;
                    break;
                default:
                    return null;
                    break;
            }
        }

        public string DoProcess(int type, string cname, string pname, double amount)
        {

            Order order = new Order();
            order.CreateDependencies(type, cname, pname);

            ProductType productType = order.ProductObj.Type;
            int value = (int)productType;

            _processPayment = GetPaymentProcess(value);
            _processPayment.PaymentProcess(order, amount);

            return "processed";
        }
    }
}

