using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPayment.Models
{
    public class Payment
    {
        public long PaymentId { get; set; }
        public long OrderId { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}
