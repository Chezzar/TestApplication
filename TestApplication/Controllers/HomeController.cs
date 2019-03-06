using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(string id)
        {

            List<Persona> personas = new List<Persona>();

            if (id == null || id == "")
                personas = new Persona().todas();
            else
                personas = new Persona().porid(int.Parse(id));


            ViewBag.info = personas;

            return View();
        }

        /*/este funciona con javascript
    public ActionResult Index(string id,string nombre)
    {

        List<Persona> personas = new List<Persona>();

        //new Persona().insertar(4,"cacarambas");
        if(id != null)
            personas = new Persona().porid(int.Parse(id));


        ViewBag.info = personas;

        return View();
    }*/

        [HttpPost]
        public ActionResult Index(string id, string nombre)
        {

            List<Persona> personas = new List<Persona>();

            new Persona().insertar(int.Parse(id),nombre);

            ViewBag.info = personas;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}