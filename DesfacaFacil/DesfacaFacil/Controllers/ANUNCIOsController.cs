﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesfacaFacil.Models;
using DAL;

namespace DesfacaFacil.Controllers
{
    public class ANUNCIOsController : Controller
    {
        private Entidades db = new Entidades();

        // GET: ANUNCIOs
        public ActionResult Index()
        {
            IDBController dbcontroller = new DBController();
            List<DBAnuncio> anuncios = dbcontroller.getAnuncios();
            return View(anuncios.ToList());
        }

        // GET: ANUNCIOs/Details/5
        /*public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANUNCIO aNUNCIO = db.ANUNCIOs.Find(id);
            if (aNUNCIO == null)
            {
                return HttpNotFound();
            }
            return View(aNUNCIO);
        }*/

        // GET: ANUNCIOs/Create
        public ActionResult Create()
        {
            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME");
            ViewBag.CID = new SelectList(db.CATEGORIAS, "CID", "NOME");
            return View();
        }

        // POST: ANUNCIOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AID,USID,CID,TIPO,STATUS,DATACRIACAO,DATAEXPIRACAO,DESCRICAO,TITULO")] ANUNCIO aNUNCIO)
        {
            if (ModelState.IsValid)
            {
                db.ANUNCIOs.Add(aNUNCIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME", aNUNCIO.USID);
            ViewBag.CID = new SelectList(db.CATEGORIAS, "CID", "NOME", aNUNCIO.CID);
            return View(aNUNCIO);
        }

        // GET: ANUNCIOs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANUNCIO aNUNCIO = db.ANUNCIOs.Find(id);
            if (aNUNCIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME", aNUNCIO.USID);
            ViewBag.CID = new SelectList(db.CATEGORIAS, "CID", "NOME", aNUNCIO.CID);
            return View(aNUNCIO);
        }

        // POST: ANUNCIOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AID,USID,CID,TIPO,STATUS,DATACRIACAO,DATAEXPIRACAO,DESCRICAO,TITULO")] ANUNCIO aNUNCIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aNUNCIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME", aNUNCIO.USID);
            ViewBag.CID = new SelectList(db.CATEGORIAS, "CID", "NOME", aNUNCIO.CID);
            return View(aNUNCIO);
        }

        // GET: ANUNCIOs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANUNCIO aNUNCIO = db.ANUNCIOs.Find(id);
            if (aNUNCIO == null)
            {
                return HttpNotFound();
            }
            return View(aNUNCIO);
        }

        // POST: ANUNCIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ANUNCIO aNUNCIO = db.ANUNCIOs.Find(id);
            db.ANUNCIOs.Remove(aNUNCIO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Visualizar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Visualizar(int id)
        {

            ANUNCIO a = db.ANUNCIOs.FirstOrDefault(x => x.AID == id);
            if (Int32.Parse(Session["IdUsuario"].ToString()) == id)
            {
                a.CANDIDATOS = db.CANDIDATOS.Where(y => y.AID == a.AID).ToList();
                ViewBag.Candidatos = db.CANDIDATOS.Where(x => x.AID == id).AsEnumerable();
            }
            else
            {
                ViewBag.Candidatos = new List<ANUNCIO>();
            }
            return View(a);

        }
    }
}
