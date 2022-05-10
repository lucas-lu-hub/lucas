using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
