using Microsoft.AspNetCore.Mvc;

namespace Products.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // TODO : should redirect to swagger page
            return Ok();
        }
    }
}
