using NUnit.Framework;
using ProductPayment.BLL;
using ProductPayment.BLL.ProcessPayment;
using ProductPayment.Models;
using System;

namespace PaymentProcess.Test
{
    public class MemberShipPaymentTest
    {
        IProcessPayment memberPaymentProcess;
       
        int type;
        string cname, pname;
        double paymentAmount;
        Order order;

        [SetUp]
        public void Setup()
        {
            type = (int)ProductType.Membership;
            cname = "new Member";
            pname = "new MemberShip Activation";
            paymentAmount = 15000.00;

            order = new Order();
            order.CreateDependencies(type, cname, pname);
        }

        [Test]
        public void NewMemberShipPaymentTest()
        {
            memberPaymentProcess = new MemberPaymentProcess();
            Assert.AreNotEqual(null, memberPaymentProcess);

            string result = memberPaymentProcess.PaymentProcess(order, paymentAmount);
            Assert.IsNotEmpty(result);
            Assert.AreEqual("success", result);
        }


    }
}