using NUnit.Framework;
using ProductPayment.BLL;
using ProductPayment.BLL.ProcessPayment;
using ProductPayment.Models;
using System;

namespace PaymentProcess.Test
{
    public class VideoSalePaymentTestVideoTrainingPaymentProcessTest
    {
        IProcessPayment videoTrainingPaymentProcess;
       
        int type;
        string cname, pname;
        double paymentAmount;
        Order order;

        [SetUp]
        public void Setup()
        {
            type = (int)ProductType.VideoTraining;
            cname = "new Video customer";
            pname = "new Ski Video Training ";
            paymentAmount = 10000.00;

            order = new Order();
            order.CreateDependencies(type, cname, pname);
        }

        [Test]
        public void NewMemberShipPaymentTest()
        {
            videoTrainingPaymentProcess = new VideoTrainingPaymentProcess();
            Assert.AreNotEqual(null, videoTrainingPaymentProcess);

            string result = videoTrainingPaymentProcess.PaymentProcess(order, paymentAmount);
            Assert.IsNotEmpty(result);
            Assert.AreEqual("success", result);
        }


    }
}