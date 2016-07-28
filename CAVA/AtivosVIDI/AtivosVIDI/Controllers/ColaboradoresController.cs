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
    public class ColaboradoresController : Controller
    {
        private CAVA db = new CAVA();

        // GET: Colaboradores
        public ActionResult Index()
        {
            var colaboradores = db.Colaboradores.Include(c => c.TipoColaboradores);
            return View(colaboradores.ToList());
        }

        // GET: Colaboradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboradores colaboradores = db.Colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            return View(colaboradores);
        }

        // GET: Colaboradores/Create
        public ActionResult Create()
        {
            ViewBag.TipoColaborador = new SelectList(db.TipoColaboradores, "Id", "Descricao");
            return View();
        }

        // POST: Colaboradores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CPF,Email,TelefoneFixo,TelefoneCelular,Cidade,Estado,NomeCompleto,Genero,TipoColaborador")] Colaboradores colaboradores)
        {
            if (ModelState.IsValid)
            {
                db.Colaboradores.Add(colaboradores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoColaborador = new SelectList(db.TipoColaboradores, "Id", "Descricao", colaboradores.TipoColaborador);
            return View(colaboradores);
        }

        // GET: Colaboradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboradores colaboradores = db.Colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoColaborador = new SelectList(db.TipoColaboradores, "Id", "Descricao", colaboradores.TipoColaborador);
            return View(colaboradores);
        }

        // POST: Colaboradores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CPF,Email,TelefoneFixo,TelefoneCelular,Cidade,Estado,NomeCompleto,Genero,TipoColaborador")] Colaboradores colaboradores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colaboradores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoColaborador = new SelectList(db.TipoColaboradores, "Id", "Descricao", colaboradores.TipoColaborador);
            return View(colaboradores);
        }

        // GET: Colaboradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboradores colaboradores = db.Colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            return View(colaboradores);
        }

        // POST: Colaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colaboradores colaboradores = db.Colaboradores.Find(id);
            db.Colaboradores.Remove(colaboradores);
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
