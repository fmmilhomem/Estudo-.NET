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
    public class SoftwaresComputadoresController : Controller
    {
        private CAVA db = new CAVA();

        // GET: SoftwaresComputadores
        public ActionResult Index()
        {
            var softwaresComputadores = db.SoftwaresComputadores.Include(s => s.Computadores).Include(s => s.Softwares);
            return View(softwaresComputadores.ToList());
        }

        // GET: SoftwaresComputadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoftwaresComputadores softwaresComputadores = db.SoftwaresComputadores.Find(id);
            if (softwaresComputadores == null)
            {
                return HttpNotFound();
            }
            return View(softwaresComputadores);
        }

        // GET: SoftwaresComputadores/Create
        public ActionResult Create()
        {
            ViewBag.ComputadorId = new SelectList(db.Computadores, "Id", "Id");
            ViewBag.SoftwareId = new SelectList(db.Softwares, "Id", "Id");
            return View();
        }

        // POST: SoftwaresComputadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SoftwareId,ComputadorId")] SoftwaresComputadores softwaresComputadores)
        {
            if (ModelState.IsValid)
            {
                db.SoftwaresComputadores.Add(softwaresComputadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComputadorId = new SelectList(db.Computadores, "Id", "ComputadorId", softwaresComputadores.ComputadorId);
            ViewBag.SoftwareId = new SelectList(db.Softwares, "Id", "SoftwareId", softwaresComputadores.SoftwareId);
            return View(softwaresComputadores);
        }

        // GET: SoftwaresComputadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoftwaresComputadores softwaresComputadores = db.SoftwaresComputadores.Find(id);
            if (softwaresComputadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComputadorId = new SelectList(db.Computadores, "Id", "ServiceTag", softwaresComputadores.ComputadorId);
            ViewBag.SoftwareId = new SelectList(db.Softwares, "Id", "NomeSoftware", softwaresComputadores.SoftwareId);
            return View(softwaresComputadores);
        }

        // POST: SoftwaresComputadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SoftwareId,ComputadorId")] SoftwaresComputadores softwaresComputadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(softwaresComputadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComputadorId = new SelectList(db.Computadores, "Id", "ServiceTag", softwaresComputadores.ComputadorId);
            ViewBag.SoftwareId = new SelectList(db.Softwares, "Id", "NomeSoftware", softwaresComputadores.SoftwareId);
            return View(softwaresComputadores);
        }

        // GET: SoftwaresComputadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoftwaresComputadores softwaresComputadores = db.SoftwaresComputadores.Find(id);
            if (softwaresComputadores == null)
            {
                return HttpNotFound();
            }
            return View(softwaresComputadores);
        }

        // POST: SoftwaresComputadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SoftwaresComputadores softwaresComputadores = db.SoftwaresComputadores.Find(id);
            db.SoftwaresComputadores.Remove(softwaresComputadores);
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
