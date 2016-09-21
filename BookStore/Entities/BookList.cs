namespace BookStore.Entities
{
    using System.Collections.Generic;

    public class BookList
    {
        public BookList()
        {
            this.Books = new List<Book>();
        }

        public List<Book> Books { get; set; }
    }
}
