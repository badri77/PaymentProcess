using ProductPayment.Models;

namespace ProductPayment.BLL
{
    public class DoProcessPaymentFactory
    {
        private IProcessPayment _processPayment;

        private IProcessPayment GetPaymentProcess(int productType)
        {
            // based on product type, generate process class.
            switch (productType)
            {
                case 0:
                    _processPayment = new PhysicalProductPaymentProcess();
                    return _processPayment;
                    
                case 1:
                    _processPayment = new BookPaymentProcess();
                    return _processPayment;
                    
                case 2:
                    _processPayment = new MemberPaymentProcess();
                    return _processPayment;
                    
                case 3:
                    _processPayment = new UpgradeMembershipPaymentProcess();
                    return _processPayment;
                   
                case 4:
                    _processPayment = new VideoPaymentProcess();
                    return _processPayment;
                    
                default:
                    return null;
                   
            }
        }

        public string DoProcess(int type, string cname, string pname, double amount)
        {

            Order order = new Order();
            order.CreateDependencies(type, cname, pname);
            ProductType productType = order.ProductObj.Type;
            int value = (int)productType;

            // get payment prcess object.
            _processPayment = GetPaymentProcess(value);
            if (_processPayment != null)
            {
                // execute the process 
                _processPayment.PaymentProcess(order, amount);
                return "processed";
            }
            else
            {
                return "Payment Not processed. Please select right product type";
            }
        }
    }
}

