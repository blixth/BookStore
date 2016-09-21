namespace BookStore.Repositories
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Entities;
    using Newtonsoft.Json;

    public class BookRepository : IBookRepository
    {
        private const string contribeUrl = "http://www.contribe.se/arbetsprov-net/books.json";

        public async Task<IEnumerable<IBook>> GetBooksAsync()
        {
            using (var client = new HttpClient())
            {
                var request = await client.GetAsync(contribeUrl);

                request.EnsureSuccessStatusCode();

                var response = await request.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<BookList>(response).Books;
            }
        }
    }
}
