namespace BookStore.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookStore.Integration;
    using BookStore.Models;
    public class BookData : IBookData
    {
        private readonly IContribeClient contribeClient;

        public BookData(IContribeClient contribeClient)
        {
            this.contribeClient = contribeClient;
        }

        public Task<IEnumerable<IBook>> GetBooksAsync()
        {
            return this.contribeClient.GetBooksAsync();
        }
    }
}
