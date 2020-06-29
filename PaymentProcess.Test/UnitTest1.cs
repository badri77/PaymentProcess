using NUnit.Framework;
using ProductPayment.BLL;
using ProductPayment.Models;
using System;

namespace PaymentProcess.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            int type;
            string cname, pname;
            double amount;
            Random random = new Random();
            type = random.Next(0, 4);
            cname = "new Customer";
            pname = "new Product";
            amount = random.Next(500, 1000);

            DoProcessPaymentFactory paymentFactory = new DoProcessPaymentFactory();
            string result = paymentFactory.DoProcess(type, cname, pname, amount);

            

            Assert.AreEqual(result, "processed");
        }
    }
}