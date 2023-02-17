public partial class Checkout
{
    public class Item
    {
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
        public string Promotion { get; set; }

        public Item(string sku, decimal unitPrice)
        {
            SKU = sku;
            UnitPrice = unitPrice;
           
        }
    }
}
