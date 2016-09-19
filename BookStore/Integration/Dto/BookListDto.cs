namespace BookStore.Integration.Dto
{
    using System.Collections.Generic;
    using Models;

    public class BookListDto
    {
        public BookListDto()
        {
            this.Books = new List<Book>();
        }

        public List<Book> Books { get; set; }
    }
}
