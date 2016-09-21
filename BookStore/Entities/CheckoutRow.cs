namespace BookStore.Entities
{
    using System;

    public class CheckoutRow
    {
        public Guid BookId { get; set; }

        public int Quantity { get; set; }
    }
}
