using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TDSTecnologia.FaceAlbum.Web.Data;
using TDSTecnologia.FaceAlbum.Web.Models;

namespace TDSTecnologia.FaceAlbum.Web.Controllers
{
    public class AlbumController : Controller
    {
        private readonly AppContexto _context;

        public AlbumController(AppContexto context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Albuns.ToList());
        }


        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Novo(Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        [HttpGet]
        public IActionResult Alterar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _context.Albuns.Find(id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        [HttpPost]
        public IActionResult Alterar(int id, Album album)
        {
            if (id != album.AlbumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        private bool AlbumExists(int id)
        {
            return _context.Albuns.Any(e => e.AlbumId == id);
        }

        [HttpPost]
        public JsonResult Excluir(int AlbumId)
        {
            var album =  _context.Albuns.Find(AlbumId);
            _context.Albuns.Remove(album);
            _context.SaveChanges();
            return Json("Album excluído com sucesso!!!");
        }
    }
}
