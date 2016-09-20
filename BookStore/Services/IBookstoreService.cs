namespace BookStore.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookStore.Models;

    public interface IBookstoreService
    {
        Task<IEnumerable<IBook>> GetBooksAsync();

        Task<IEnumerable<IBook>> GetBooksAsync(string searchString);
    }
}
