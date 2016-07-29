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
    public class SoftwaresController : Controller
    {
        private CAVA db = new CAVA();

        // GET: Softwares
        public ActionResult Index()
        {
            return View(db.Softwares.ToList());
        }

        // GET: Softwares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Softwares softwares = db.Softwares.Find(id);
            if (softwares == null)
            {
                return HttpNotFound();
            }
            return View(softwares);
        }

        // GET: Softwares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Softwares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomeSoftware,MaximoInstalacoes,KeySoftware,Valor,Fornecedor,OrigemCompra,DataCompra")] Softwares softwares)
        {
            if (ModelState.IsValid)
            {
                db.Softwares.Add(softwares);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(softwares);
        }

        // GET: Softwares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Softwares softwares = db.Softwares.Find(id);
            if (softwares == null)
            {
                return HttpNotFound();
            }
            return View(softwares);
        }

        // POST: Softwares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomeSoftware,MaximoInstalacoes,KeySoftware,Valor,Fornecedor,OrigemCompra,DataCompra")] Softwares softwares)
        {
            if (ModelState.IsValid)
            {
                db.Entry(softwares).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(softwares);
        }

        // GET: Softwares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Softwares softwares = db.Softwares.Find(id);
            if (softwares == null)
            {
                return HttpNotFound();
            }
            return View(softwares);
        }

        // POST: Softwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Softwares softwares = db.Softwares.Find(id);
            db.Softwares.Remove(softwares);
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
