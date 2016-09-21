namespace BookStore.Entities
{
    public interface IOrderRow
    {
        IBook Book { get; set; }
        int Quantity { get; set; }
        int Backordered { get; set; }
    }
}
