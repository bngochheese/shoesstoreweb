namespace ShoesStoreWebsite.Models
{
    public class Product_Item
    {
        public Shoes Shoes { get; set; }
        public int Quantity { get; set; }

        private decimal _SubTotal;
        public decimal SubTotal
        {
            get { return _SubTotal; }
            set { _SubTotal = Shoes.Price * Quantity; }
        }
    }

}
