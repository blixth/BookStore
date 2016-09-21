namespace BookStore.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BookStore.Entities;

    public class OrderService : IOrderService
    {
        private readonly IBookstoreService bookstoreService;

        public OrderService(IBookstoreService bookstoreService)
        {
            this.bookstoreService = bookstoreService;
        }

        public async Task<Order> CreateOrderAsync(IEnumerable<CheckoutRow> checkoutRows)
        {
            var books = await this.bookstoreService.GetBooksAsync();
            var order = new Order();

            foreach (var checkoutRow in checkoutRows)
            {
                order.Rows.Add(this.CreateOrderRow(checkoutRow, books));
            }

            // Should probably save the order to a db.

            return order;
        }

        private OrderRow CreateOrderRow(CheckoutRow checkoutRow, IEnumerable<IBook> books)
        {
            var book = books.SingleOrDefault(x =>
            {
                var o = x as Book;
                return o != null && o.Id == checkoutRow.BookId;
            });

            if (book != null)
            {
                var backordered = (book as Book).InStock > checkoutRow.Quantity
                    ? 0
                    : checkoutRow.Quantity - (book as Book).InStock;

                return new OrderRow()
                {
                    Book = book,
                    Quantity = backordered != 0 ? (book as Book).InStock : checkoutRow.Quantity,
                    Backordered = backordered
                };
            }

            return null;
        }
    }
}
