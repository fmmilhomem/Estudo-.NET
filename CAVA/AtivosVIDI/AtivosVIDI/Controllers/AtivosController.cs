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
    public class AtivosController : Controller
    {
        private CAVA db = new CAVA();

        // GET: Ativos
        public ActionResult Index()
        {
            var ativos = db.Ativos.Include(a => a.Colaboradores);
            return View(ativos.ToList());
        }

        // GET: Ativos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ativos ativos = db.Ativos.Find(id);
            if (ativos == null)
            {
                return HttpNotFound();
            }
            return View(ativos);
        }

        // GET: Ativos/Create
        public ActionResult Create()
        {
            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "Id", db.Colaboradores);
            return View();
        }

        // POST: Ativos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroSerie,Marca,Modelo,ColaboradorId,Origem,Valor,Fornecedor,OrigemCompra,DataCompra,NumeroPatrimonio")] Ativos ativos)
        {
            if (ModelState.IsValid)
            {
                db.Ativos.Add(ativos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "ColaboradorId", ativos.ColaboradorId);
            return View(ativos);
        }

        // GET: Ativos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ativos ativos = db.Ativos.Find(id);
            if (ativos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "ColaboradorId", ativos.ColaboradorId);
            return View(ativos);
        }

        // POST: Ativos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroSerie,Marca,Modelo,ColaboradorId,Origem,Valor,Fornecedor,OrigemCompra,DataCompra,NumeroPatrimonio")] Ativos ativos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ativos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "ColaboradorId", ativos.ColaboradorId);
            return View(ativos);
        }

        // GET: Ativos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ativos ativos = db.Ativos.Find(id);
            if (ativos == null)
            {
                return HttpNotFound();
            }
            return View(ativos);
        }

        // POST: Ativos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ativos ativos = db.Ativos.Find(id);
            db.Ativos.Remove(ativos);
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
