namespace BookStore.Integration
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Dto;
    using Models;
    using Newtonsoft.Json;

    public class ContribeClient : IContribeClient
    {
        private const string contribeUrl = "http://www.contribe.se/arbetsprov-net/books.json";

        public Task<IEnumerable<IBook>> GetBooksAsync()
        {
            return CreateHttpClient().GetAsync(contribeUrl).ContinueWith(request =>
            {
                var response = request.Result;
                response.EnsureSuccessStatusCode();

                return
                    response.Content.ReadAsStringAsync()
                        .ContinueWith(
                            t => (IEnumerable<IBook>)JsonConvert.DeserializeObject<BookListDto>(t.Result).Books);
            }).Unwrap();
        }

        private static HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();

            return httpClient;
        }
    }
}
