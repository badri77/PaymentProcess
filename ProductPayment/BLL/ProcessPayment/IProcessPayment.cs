using ProductPayment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPayment.BLL.ProcessPayment
{
    public interface IProcessPayment
    {
        string PaymentProcess(Order order, double amount);
    }
    
}
