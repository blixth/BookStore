namespace BookStore.Entities
{
    public class OrderRow : IOrderRow
    {
        public IBook Book { get; set; }
        public int Quantity { get; set; }
        public int Backordered { get; set; }
    }
}
