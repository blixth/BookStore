namespace BookStore.Integration
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookStore.Models;


    public interface IContribeClient
    {
        Task<IEnumerable<IBook>> GetBooksAsync();
    }
}
