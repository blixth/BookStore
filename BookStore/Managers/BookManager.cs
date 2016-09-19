namespace BookStore.Managers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data;
    using Models;

    public class BookManager : IBookManager
    {
        private readonly IBookData bookData;

        public BookManager(IBookData bookData)
        {
            this.bookData = bookData;
        }

        public Task<IEnumerable<IBook>> GetBooksAsync()
        {
            var books = this.bookData.GetBooksAsync();

            return books;
        }
    }
}
