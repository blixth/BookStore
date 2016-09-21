namespace BookStore.Managers.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BookStore.Services;
    using Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Repositories;



    [TestClass()]
    public class BookstoreServiceTests
    {
        private Mock<IBookRepository> bookRepository;
        private IBookstoreService bookstoreService;

        [TestInitialize]
        public void Setup()
        {
            this.bookRepository = new Mock<IBookRepository>();
            this.bookstoreService = new BookstoreService(this.bookRepository.Object);
        }

        [TestMethod]
        public async Task GetBooksAsync_Test()
        {
            var books = new List<IBook>()
            {
                new Book() {Author = "Author", InStock = 0, Price = 0, Title = "TheBestBook"},
                new Book() {Author = "JOHNCENA", Title = "BAPADAPAOW", InStock = 0,Price = 9001m}
            };

            this.bookRepository.Setup(x => x.GetBooksAsync()).Returns(Task.FromResult((IEnumerable<IBook>)books));

            var result = await this.bookstoreService.GetBooksAsync("");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task GetBooksAsync_SearchAuthor_Test()
        {
            var books = new List<IBook>()
            {
                new Book() {Author = "Author", InStock = 0, Price = 0, Title = "TheBestBook"},
                new Book() {Author = "JOHNCENA", Title = "BAPADAPAOW", InStock = 0,Price = 9001m}
            };

            this.bookRepository.Setup(x => x.GetBooksAsync()).Returns(Task.FromResult((IEnumerable<IBook>)books));

            var result = await this.bookstoreService.GetBooksAsync("johncena");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public async Task GetBooksAsync_SearchTitle_Test()
        {
            var books = new List<IBook>()
            {
                new Book() {Author = "Author", InStock = 0, Price = 0, Title = "TheBestBook"},
                new Book() {Author = "JOHNCENA", Title = "BAPADAPAOW", InStock = 0,Price = 9001m}
            };

            this.bookRepository.Setup(x => x.GetBooksAsync()).Returns(Task.FromResult((IEnumerable<IBook>)books));

            var result = await this.bookstoreService.GetBooksAsync("THEBESTBOOK");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public async Task GetBooksAsync_SearchPrice_Test()
        {
            var books = new List<IBook>()
            {
                new Book() {Author = "Author", InStock = 0, Price = 1337, Title = "TheBestBook"},
                new Book() {Author = "JOHNCENA", Title = "BAPADAPAOW", InStock = 0,Price = 9001m}
            };

            this.bookRepository.Setup(x => x.GetBooksAsync()).Returns(Task.FromResult((IEnumerable<IBook>)books));

            var result = await this.bookstoreService.GetBooksAsync("1337");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public async Task GetBooksAsync_SearchNoMatch_Test()
        {
            var books = new List<IBook>()
            {
                new Book() {Author = "Author", InStock = 0, Price = 0, Title = "TheBestBook"},
                new Book() {Author = "JOHNCENA", Title = "BAPADAPAOW", InStock = 0,Price = 9001m}
            };

            this.bookRepository.Setup(x => x.GetBooksAsync()).Returns(Task.FromResult((IEnumerable<IBook>)books));

            var result = await this.bookstoreService.GetBooksAsync("404");

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public async Task GetBooksAsync_SearchNullTitle_Test()
        {
            var books = new List<IBook>()
            {
                new Book() {Author = "Author", InStock = 0, Price = 0, Title = null},
                new Book() {Author = "JOHNCENA", Title = "BAPADAPAOW", InStock = 0,Price = 9001m}
            };

            this.bookRepository.Setup(x => x.GetBooksAsync()).Returns(Task.FromResult((IEnumerable<IBook>)books));

            var result = await this.bookstoreService.GetBooksAsync("author");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public async Task GetBooksAsync_SearchNullAuthor_Test()
        {
            var books = new List<IBook>()
            {
                new Book() {Author = "Author", InStock = 0, Price = 0, Title = "TheBestBook"},
                new Book() {Author = null, Title = "BAPADAPAOW", InStock = 0,Price = 9001m}
            };

            this.bookRepository.Setup(x => x.GetBooksAsync()).Returns(Task.FromResult((IEnumerable<IBook>)books));

            var result = await this.bookstoreService.GetBooksAsync("BAPADAPAOW");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }
    }
}