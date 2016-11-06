﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace DesfacaFacil.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Session["IdUsuario"] = -1;
            return View();
        }
        public ActionResult Pesquisa(string busca)
        {
            IDBController dbcontroller = new DBController();
            List<DBAnuncio> lista = dbcontroller.getAnuncios("titulo like '%" + busca + "%' or descricao like '%" + busca + "%'");

            return View(lista);

        }
    }
}