using System.Globalization;

namespace BookStore.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Managers;
    using Models;

    [EnableCors("http://localhost:34659", "*", "*")]
    public class BooksController : ApiController, IBooksController
    {
        private readonly IBookManager bookManager;

        public BooksController(IBookManager bookManager)
        {
            this.bookManager = bookManager;
        }

        [HttpGet]
        public async Task<IEnumerable<IBook>> GetBooksAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                var books = await this.bookManager.GetBooksAsync();

                return books;
            }

            searchString.ToLower();

            return
                await this.bookManager.GetBooksAsync().ContinueWith(books => (books.Result as IEnumerable<Book>).Where(
                    x =>
                        x.Title.ToLower().Contains(searchString) ||
                        x.Author.ToLower().Contains(searchString) ||
                        x.InStock.ToString().ToLower().Contains(searchString) ||
                        x.Price.ToString(CultureInfo.CurrentCulture).ToLower().Contains(searchString))
                    .ToList());
        }
    }
}