using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Encodings.Web;

namespace NotiUcse.Controllers
{
    public class NewsController : Controller
    {
        // 
        // GET: /News/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /News/Noticias

        public string Noticias()
        {
            return "Un día como hoy (10/08) pero en 2010 en la Antártida se registra la temperatura más baja de la historia de -93,2 °C.";
        }

        public IActionResult NoticiasPorAnio(int id)
        {
            ViewData["TextoNoticia"] = String.Format("Un día como hoy (10/08) pero en {0} en la Antártida se registra la temperatura más baja de la historia de -93,2 °C.", id);

            return View();
        }
    }
}