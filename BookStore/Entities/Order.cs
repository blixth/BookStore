namespace BookStore.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class Order : IOrder
    {
        public Order()
        {
            this.Rows = new List<OrderRow>();
        }

        public List<OrderRow> Rows { get; set; }

        public decimal TotalAmount => this.Rows.Sum(row => row.Quantity * row.Book.Price);
    }
}
