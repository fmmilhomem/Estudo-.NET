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
    public class ComputadoresController : Controller
    {
        private CAVA db = new CAVA();

        // GET: Computadores
        public ActionResult Index()
        {
            var computadores = db.Computadores.Include(c => c.Colaboradores);
            return View(computadores.ToList());
        }

        // GET: Computadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computadores computadores = db.Computadores.Find(id);
            if (computadores == null)
            {
                return HttpNotFound();
            }
            return View(computadores);
        }

        // GET: Computadores/Create
        public ActionResult Create()
        {
            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "CPF");
            return View();
        }

        // POST: Computadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ServiceTag,NumeroSerie,NumeroPatrimonio,Processador,Marca,Modelo,ColaboradorId,Origem,Obs,VersaoWindows,Valor,Fornecedor,OrigemCompra,DataCompra")] Computadores computadores)
        {
            if (ModelState.IsValid)
            {
                db.Computadores.Add(computadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "CPF", computadores.ColaboradorId);
            return View(computadores);
        }

        // GET: Computadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computadores computadores = db.Computadores.Find(id);
            if (computadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "CPF", computadores.ColaboradorId);
            return View(computadores);
        }

        // POST: Computadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ServiceTag,NumeroSerie,NumeroPatrimonio,Processador,Marca,Modelo,ColaboradorId,Origem,Obs,VersaoWindows,Valor,Fornecedor,OrigemCompra,DataCompra")] Computadores computadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(computadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "CPF", computadores.ColaboradorId);
            return View(computadores);
        }

        // GET: Computadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computadores computadores = db.Computadores.Find(id);
            if (computadores == null)
            {
                return HttpNotFound();
            }
            return View(computadores);
        }

        // POST: Computadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Computadores computadores = db.Computadores.Find(id);
            db.Computadores.Remove(computadores);
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
