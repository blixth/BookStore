namespace BookStore.Integration.Dto
{
    using System.Collections.Generic;
    using Models;

    public class BookList
    {
        public BookList()
        {
            this.Books = new List<Book>();
        }

        public List<Book> Books { get; set; }
    }
}
