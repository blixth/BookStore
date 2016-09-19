namespace BookStore.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookStore.Models;
    public interface IBooksController
    {
        Task<IEnumerable<IBook>> GetBooksAsync(string searchString);
    }
}