﻿namespace BookStore.Models
{
    using System;

    public class Book : IBook
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
    }
}
