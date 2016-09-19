namespace BookStore.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IBookData
    {
        Task<IEnumerable<IBook>> GetBooksAsync();
    }
}
