namespace BookStore.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(IEnumerable<CheckoutRow> checkoutRows);
    }
}
