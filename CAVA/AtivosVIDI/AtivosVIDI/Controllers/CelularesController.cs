using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AtivosVIDI.Models;

namespace AtivosVIDI.Controllers
{
    public class CelularesController : Controller
    {
        private CAVA db = new CAVA();

        // GET: Celulares
        public ActionResult Index()
        {
            var celulares = db.Celulares.Include(c => c.Colaboradores);
            return View(celulares.ToList());
        }

        // GET: Celulares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celulares celulares = db.Celulares.Find(id);
            if (celulares == null)
            {
                return HttpNotFound();
            }
            return View(celulares);
        }

        // GET: Celulares/Create
        public ActionResult Create()
        {
            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "Id");
            return View();
        }

        // POST: Celulares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ColaboradorId,Modelo,OrigemCelular,NumeroPatrimonio,SenhaDesbloqueio,NumeroSerie,Imei,LoginLoja,SenhaLoja,Marca,Valor,Fornecedor,OrigemCompra,DataCompra")] Celulares celulares)
        {
            if (ModelState.IsValid)
            {
                db.Celulares.Add(celulares);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "ColaboradorId", celulares.ColaboradorId);
            return View(celulares);
        }

        // GET: Celulares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celulares celulares = db.Celulares.Find(id);
            if (celulares == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "CPF", celulares.ColaboradorId);
            return View(celulares);
        }

        // POST: Celulares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ColaboradorId,Modelo,OrigemCelular,NumeroPatrimonio,SenhaDesbloqueio,NumeroSerie,Imei,LoginLoja,SenhaLoja,Marca,Valor,Fornecedor,OrigemCompra,DataCompra")] Celulares celulares)
        {
            if (ModelState.IsValid)
            {
                db.Entry(celulares).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "CPF", celulares.ColaboradorId);
            return View(celulares);
        }

        // GET: Celulares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celulares celulares = db.Celulares.Find(id);
            if (celulares == null)
            {
                return HttpNotFound();
            }
            return View(celulares);
        }

        // POST: Celulares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Celulares celulares = db.Celulares.Find(id);
            db.Celulares.Remove(celulares);
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
    }
}
