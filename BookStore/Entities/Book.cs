namespace BookStore.Models
{
    public class Book : IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
    }
}
