namespace ProductPayment.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public ProductType Type {get; set;}
        public double BaseRate { get; set; }

    }




    public enum ProductType
    { 
        Physical = 0,
        Book = 1,
        Membership =2,
        UpgradeMembership =3,
        VideoTraining = 4
    }
}
