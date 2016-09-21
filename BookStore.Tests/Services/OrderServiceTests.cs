using System.Linq;

namespace BookStore.Services.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookStore.Services;
    using Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class OrderServiceTests
    {
        private Mock<IBookstoreService> bookstoreService;
        private IOrderService orderService;

        [TestInitialize]
        public void Setup()
        {
            this.bookstoreService = new Mock<IBookstoreService>();
            this.orderService = new OrderService(this.bookstoreService.Object);
        }

        [TestMethod]
        public async Task CreateOrderAsync_Test()
        {
            var bookId = Guid.NewGuid();
            var books = new List<IBook>()
            {
                new Book()
                {
                    Title = "Title",
                    Author = "Author",
                    InStock = 15,
                    Price = 100m,
                    Id = bookId
                }
            };

            var checkOutRows = new List<CheckoutRow>()
            {
                new CheckoutRow()
                {
                    Quantity = 5,
                    BookId = bookId
                }
            };

            this.bookstoreService.Setup(x => x.GetBooksAsync()).Returns(Task.FromResult((IEnumerable<IBook>)books));

            var order = await this.orderService.CreateOrderAsync(checkOutRows);

            Assert.AreEqual(500m, order.TotalAmount);
            Assert.AreEqual(5, order.Rows.First().Quantity);
            Assert.AreEqual(0, order.Rows.First().Backordered);
        }

        [TestMethod]
        public void CreateOrderRow_Backordered_Test()
        {
            var bookId = Guid.NewGuid();
            var books = new List<IBook>()
            {
                new Book()
                {
                    Title = "Title",
                    Author = "Author",
                    InStock = 5,
                    Price = 100m,
                    Id = bookId
                }
            };

            var checkoutRow = new CheckoutRow()
            {
                Quantity = 20,
                BookId = bookId
            };


            var privateObject = new PrivateObject(this.orderService);

            var row = (OrderRow)privateObject.Invoke("CreateOrderRow", new object[]
            {
                checkoutRow,
                books
            });

            Assert.AreEqual(5, row.Quantity);
            Assert.AreEqual(15, row.Backordered);
        }

        [TestMethod]
        public void CreateOrderRow_Test()
        {
            var bookId = Guid.NewGuid();
            var books = new List<IBook>()
            {
                new Book()
                {
                    Title = "Title",
                    Author = "Author",
                    InStock = 20,
                    Price = 100m,
                    Id = bookId
                }
            };


            var checkoutRow = new CheckoutRow()
            {
                Quantity = 10,
                BookId = bookId
            };


            var privateObject = new PrivateObject(this.orderService);

            var row = (OrderRow)privateObject.Invoke("CreateOrderRow", new object[]
            {
                checkoutRow,
                books
            });

            Assert.AreEqual(10, row.Quantity);
            Assert.AreEqual(0, row.Backordered);
        }
    }
}