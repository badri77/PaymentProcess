using NUnit.Framework;
using ProductPayment.BLL.ProcessPayment;
using ProductPayment.Models;
using System;

namespace PaymentProcess.Test
{
    public class MemberShipUpgradePaymentTest
    {
        IProcessPayment upgradeMembershipPaymentProcess;
       
        int type;
        string cname, pname;
        double paymentAmount;
        Order order;

        [SetUp]
        public void Setup()
        {
            type = (int)ProductType.UpgradeMembership;
            cname = "Member Upgrade";
            pname = "Upgrade MemberShip Activation";
            paymentAmount = 25000.00;

            order = new Order();
            order.CreateDependencies(type, cname, pname);
        }

        [Test]
        public void NewMemberShipPaymentTest()
        {
            upgradeMembershipPaymentProcess = new UpgradeMembershipPaymentProcess();
            Assert.AreNotEqual(null, upgradeMembershipPaymentProcess);

            string result = upgradeMembershipPaymentProcess.PaymentProcess(order, paymentAmount);
            Assert.IsNotEmpty(result);
            Assert.AreEqual("success", result);
        }


    }
}