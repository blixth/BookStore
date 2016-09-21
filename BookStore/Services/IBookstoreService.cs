namespace BookStore.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    public interface IBookstoreService
    {
        Task<IEnumerable<IBook>> GetBooksAsync(string searchString);
        Task<IEnumerable<IBook>> GetBooksAsync();
    }
}
