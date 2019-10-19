using Microsoft.AspNetCore.Mvc;

namespace TDSTecnologia.FaceAlbum.Web.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
