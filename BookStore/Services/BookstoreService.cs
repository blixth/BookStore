namespace BookStore.Services
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using Repositories;

    public class BookstoreService : IBookstoreService
    {
        private readonly IBookRepository bookRepository;

        public BookstoreService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<IEnumerable<IBook>> GetBooksAsync()
        {
            return await this.bookRepository.GetBooksAsync();
        }

        public async Task<IEnumerable<IBook>> GetBooksAsync(string searchString)
        {
            var books = await this.bookRepository.GetBooksAsync();

            return
                books?.Where(
                    x =>
                        (x.Title?.ToLower().Contains(searchString.ToLower()) ?? false) ||
                        (x.Author?.ToLower().Contains(searchString.ToLower()) ?? false) ||
                        x.Price.ToString(CultureInfo.CurrentCulture).ToLower().Contains(searchString.ToLower()))
                    .ToList();
        }
    }
}
