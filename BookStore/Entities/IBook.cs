namespace BookStore.Models
{
    public interface IBook
    {
        string Title { get; set; }
        string Author { get; set; }
        decimal Price { get; set; }
    }
}
