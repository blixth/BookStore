namespace BookStore.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Models;
    using Services;

    [EnableCors("http://localhost:34659", "*", "*")]
    public class BooksController : ApiController, IBooksController
    {
        private readonly IBookstoreService bookstoreService;

        public BooksController(IBookstoreService bookstoreService)
        {
            this.bookstoreService = bookstoreService;
        }

        [HttpGet]
        public async Task<IEnumerable<IBook>> GetBooksAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return await this.bookstoreService.GetBooksAsync();
            }

            return await this.bookstoreService.GetBooksAsync(searchString);
        }
    }
}