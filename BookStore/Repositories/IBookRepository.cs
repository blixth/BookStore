namespace BookStore.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IBookRepository
    {
        Task<IEnumerable<IBook>> GetBooksAsync();
    }
}
