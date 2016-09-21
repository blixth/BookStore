namespace BookStore.WebApi.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    public interface ICheckoutsController
    {
        Task<IHttpActionResult> Post(dynamic checkout);
    }
}