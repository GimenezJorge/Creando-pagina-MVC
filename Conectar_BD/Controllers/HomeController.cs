using Conectar_BD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Conectar_BD.Controllers
{
    public class HomeController : Controller
    {
        Bdg3Context db = new Bdg3Context();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }




        public IActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Usuario usuario)
        {
            if (db.Usuarios.Any(x => x.Email == usuario.Email))
            {
                ViewBag.Notification = "Esta cuenta ya existe";
                return View();
            }
            else
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();

                // HttpContext.Session.SetString("idUsuario", usuario.IdUsuario.ToString());
                HttpContext.Session.SetString("email", usuario.Email.ToString());
                HttpContext.Session.SetString("clave", usuario.Clave.ToString());
                return RedirectToAction("Index", "Home");
                
            }
        }
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(Usuario usuario)
        {
            var checkLogin = db.Usuarios.Where(x => x.Email.Equals(usuario.Email) && x.Clave.Equals(usuario.Clave)).FirstOrDefault();
            if (checkLogin != null)
            {
                HttpContext.Session.SetString("email", usuario.Email.ToString());
                HttpContext.Session.SetString("clave", usuario.Clave.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Email o clave incorrectas";
            }
            return View();
        }
    }
}
