using NUnit.Framework;
using ProductPayment.BLL;
using ProductPayment.BLL.ProcessPayment;
using ProductPayment.Models;
using System;

namespace PaymentProcess.Test
{
    public class PhysicalPaymentTest
    {
        IProcessPayment PhysicalPaymentProcess;
        IGeneratePackageSlipProcessCommission generatePackageSlip;
        int type;
        string cname, pname;
        double paymentAmount;
        Order order;

        [SetUp]
        public void Setup()
        {
            type = (int)ProductType.Physical;
            cname = "new Customer";
            pname = "new Mobile";
            paymentAmount = 2000.00;

            order = new Order();
            order.CreateDependencies(type, cname, pname);
        }

        [Test]
        public void TestPhysicalPaymentProcess()
        {
            PhysicalPaymentProcess = new PhysicalProductPaymentProcess();
            Assert.AreNotEqual(null, PhysicalPaymentProcess);

            string result = PhysicalPaymentProcess.PaymentProcess(order, paymentAmount);

            Assert.AreEqual("success", result);
        }

        [Test]
        public void TestGeneratePackageSlip()
        {
            generatePackageSlip = new GeneratePackageSlipProcessCommission();
            Assert.AreNotEqual(null, generatePackageSlip);

            string result = generatePackageSlip.GeneratePackingSlip(order);

            Assert.IsNotNull(result);
            Assert.AreNotEqual(string.Empty, result);
        }

        [Test]
        public void TestAgentCommission()
        {
            generatePackageSlip = new GeneratePackageSlipProcessCommission();
            Assert.AreNotEqual(null, generatePackageSlip);

            Payment payment;
            payment = new Payment();
            payment.OrderId = order.OrderId;
            payment.PaymentAmount = paymentAmount;
            payment.PaymentDate = DateTime.UtcNow;

            double commission = generatePackageSlip.ProcessCommission(payment);

            Assert.Greater(commission, 0.0);
            
        }

    }
}