using Microsoft.AspNetCore.Mvc;

namespace TDSTecnologia.FaceAlbum.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
