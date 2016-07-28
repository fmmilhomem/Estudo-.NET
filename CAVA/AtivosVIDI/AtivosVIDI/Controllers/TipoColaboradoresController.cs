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
    public class TipoColaboradoresController : Controller
    {
        private CAVA db = new CAVA();

        // GET: TipoColaboradores
        public ActionResult Index()
        {
            return View(db.TipoColaboradores.ToList());
        }

        // GET: TipoColaboradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoColaboradores tipoColaboradores = db.TipoColaboradores.Find(id);
            if (tipoColaboradores == null)
            {
                return HttpNotFound();
            }
            return View(tipoColaboradores);
        }

        // GET: TipoColaboradores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoColaboradores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] TipoColaboradores tipoColaboradores)
        {
            if (ModelState.IsValid)
            {
                db.TipoColaboradores.Add(tipoColaboradores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoColaboradores);
        }

        // GET: TipoColaboradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoColaboradores tipoColaboradores = db.TipoColaboradores.Find(id);
            if (tipoColaboradores == null)
            {
                return HttpNotFound();
            }
            return View(tipoColaboradores);
        }

        // POST: TipoColaboradores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] TipoColaboradores tipoColaboradores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoColaboradores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoColaboradores);
        }

        // GET: TipoColaboradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoColaboradores tipoColaboradores = db.TipoColaboradores.Find(id);
            if (tipoColaboradores == null)
            {
                return HttpNotFound();
            }
            return View(tipoColaboradores);
        }

        // POST: TipoColaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoColaboradores tipoColaboradores = db.TipoColaboradores.Find(id);
            db.TipoColaboradores.Remove(tipoColaboradores);
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
