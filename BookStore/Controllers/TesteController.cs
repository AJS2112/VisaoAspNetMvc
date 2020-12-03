using BookStore.Domain;
using BookStore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [RoutePrefix("teste")]
    [Route("{action=Dados}")]
    //[LogActionFilter] Filtro local para todo o controller
    public class TesteController : Controller
    {
        public ViewResult Dados(int id)
        {
            ViewBag.Categoria = "Produtos de Limpeza";
            ViewData["Categoria"] = "Produtos de Informática";
            TempData["Catergoria"] = "Produtos de Escritório";
            Session["Categoria"] = "Móveis";

            return View(id);
        }
        public JsonResult UmaAction(int id, string nome)
        {
            var autor = new Autor { Id = id, Nome = nome };

            return Json(autor, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("Autor")]
        public JsonResult ActionDois(Autor autor)
        {
            return Json(autor);
        }

        [Route("minharota/{id?}")]
        public string MinhaAction(int? id)
        {
            return "OK! Cheguei na rota!";
        }

        [Route("~/rotaignorada/{id?}")]
        public string MinhaAction2(int? id)
        {
            return "OK! Cheguei na rota!";
        }

        [Route("rota/{categoria:alpha:minlength(3)}")]
        public string MinhaAction3(string categoria)
        {
            return "OK! Cheguei na rota! " + categoria;
        }

        //[Route("rota/estacao/{estacao:(primavera|verao|outono|inverno)}")]
        //public string MinhaAction4(string estacao)
        //{
        //    return "Ola, estamos no  " + estacao;
        //}
    }
}