﻿namespace BookStore.WebApi.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    public interface IBooksController
    {
        Task<IHttpActionResult> GetBooksAsync(string searchString);
    }
}