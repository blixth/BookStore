using System;

namespace BookStore.Services
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Entities;
    using Repositories;

    public class BookstoreService : IBookstoreService
    {
        private readonly IBookRepository bookRepository;
        private string bookStoreServiceNamespace = "33E7770A-7631-4F10-99DB-706F0D03E882";

        public BookstoreService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<IEnumerable<IBook>> GetBooksAsync()
        {
            var books = await this.bookRepository.GetBooksAsync();

            foreach (var book in books)
            {
                var o = book as Book;
                if (o != null)
                {
                    o.Id = this.GenerateGuid(book);
                }
            }

            return books;
        }

        public async Task<IEnumerable<IBook>> GetBooksAsync(string searchString)
        {
            var books = await this.GetBooksAsync();

            if (string.IsNullOrEmpty(searchString))
            {
                return books;
            }

            return
                books?.Where(
                    x =>
                        (x.Title?.ToLower().Contains(searchString.ToLower()) ?? false) ||
                        (x.Author?.ToLower().Contains(searchString.ToLower()) ?? false) ||
                        x.Price.ToString(CultureInfo.CurrentCulture).ToLower().Contains(searchString.ToLower()))
                    .ToList();
        }

        private Guid GenerateGuid(IBook book)
        {
            string input = $"{bookStoreServiceNamespace}:{book.Title}:{book.Author}:{book.Price}";

            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.Default.GetBytes(input));

                return new Guid(hash);
            }
        }
    }
}
