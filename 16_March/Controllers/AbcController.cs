using Microsoft.AspNetCore.Mvc;

namespace _16_March.Controllers
{
    public class AbcController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
