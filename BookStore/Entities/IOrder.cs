namespace BookStore.Entities
{
    using System.Collections.Generic;

    public interface IOrder
    {
        List<OrderRow> Rows { get; set; }
        decimal TotalAmount { get; }
    }
}
