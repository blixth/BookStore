namespace BookStore.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    public interface IBookRepository
    {
        Task<IEnumerable<IBook>> GetBooksAsync();
    }
}
