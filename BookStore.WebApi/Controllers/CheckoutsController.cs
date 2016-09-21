namespace BookStore.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;
    using BookStore.Services;
    using Entities;


    public class CheckoutsController : ApiController, ICheckoutsController
    {
        private readonly IOrderService checkoutService;

        public CheckoutsController(IOrderService checkoutService)
        {
            this.checkoutService = checkoutService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(dynamic checkout)
        {
            var checkOutRows = new List<CheckoutRow>();

            foreach (var row in checkout.rows)
            {
                checkOutRows.Add(new CheckoutRow()
                {
                    BookId = row.id,
                    Quantity = row.quantity
                });
            }

            var order = await this.checkoutService.CreateOrderAsync(checkOutRows);

            return this.Ok(order);
        }
    }
}