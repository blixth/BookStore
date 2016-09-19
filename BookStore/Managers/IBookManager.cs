namespace BookStore.Managers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookStore.Models;

    public interface IBookManager
    {
        Task<IEnumerable<IBook>> GetBooksAsync();
    }
}
