using System;

namespace ProductPayment.Models
{
    public class Order
    {
        public long OrderId { get; set; }
        public long CustomerId { get; set; }
        public long ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderTotalAmount { get; set; }
        public virtual Product ProductObj { get; set; }
        public virtual Customer CustomerObj { get; set; }

        // instead of constructor, to minimize effort, take complex func to create all objects at once for the sample only
        public void CreateDependencies(int producttype, string customername, string productname)
        {
            ProductType type = (ProductType)Enum.ToObject(typeof(ProductType), producttype);
            Customer cust = new Customer();
            cust.CustomerName = customername;
            cust.AddressLine1 = "address line1, address line2";
            cust.City = "Hyderabad";
            cust.CustomerId = 1;
            cust.EmailId = "customer@abc.com";
            cust.phone = "1234567890";
            CustomerObj = cust;

            Product product = new Product();
            product.Id = 1;
            product.ProductName = productname;
            product.Type = type;
            product.BaseRate = 100.00;
            ProductObj = product;

            OrderId = 1;
            OrderDate = DateTime.Now;
            OrderTotalAmount = ProductObj.BaseRate;
            CustomerId = CustomerObj.CustomerId;
            ProductId = ProductObj.Id;
        }
    }

    public class OrderDetails
    {
        public long OrderDetailsId { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
    }

}
