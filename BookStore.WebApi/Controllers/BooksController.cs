namespace BookStore.WebApi.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using Services;

    public class BooksController : ApiController, IBooksController
    {
        private readonly IBookstoreService bookstoreService;

        public BooksController(IBookstoreService bookstoreService)
        {
            this.bookstoreService = bookstoreService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetBooksAsync(string searchString)
        {
            var books = await this.bookstoreService.GetBooksAsync(searchString);

            return this.Ok(books);
        }
    }
}