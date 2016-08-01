using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AtivosVIDI.Models;
using System.Data.Entity.Validation;
using System.Text;

namespace AtivosVIDI.Controllers
{
    public class ChipsController : Controller
    {
        private CAVA db = new CAVA();

        // GET: Chips
        public ActionResult Index()
        {
            var chips = db.Chips.Include(c => c.Colaboradores);
            return View(chips.ToList());
        }

        // GET: Chips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chips chips = db.Chips.Find(id);
            if (chips == null)
            {
                return HttpNotFound();
            }
            return View(chips);
        }

        // GET: Chips/Create
        public ActionResult Create()
        {
            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "Id");
            return View();
        }

        // POST: Chips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroChip,Conta,Ativado,Plano,ColaboradorId")] Chips chips)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Chips.Add(chips);
                    Ativos ativo = new Ativos();
                    ativo.Chips = chips;
                    db.Ativos.Add(ativo);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        sb.AppendLine(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            sb.AppendLine(string.Format("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage));
                        }
                    }
                    var teste = sb.ToString();
                }
                return RedirectToAction("Index");
            }

            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "ColaboradorId", chips.ColaboradorId);
            return View(chips);
        }

        // GET: Chips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chips chips = db.Chips.Find(id);
            if (chips == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "ColaboradorId", chips.ColaboradorId);
            return View(chips);
        }

        // POST: Chips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroChip,Conta,Ativado,Plano,ColaboradorId")] Chips chips)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chips).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColaboradorId = new SelectList(db.Colaboradores, "Id", "Id", chips.ColaboradorId);
            return View(chips);
        }

        // GET: Chips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chips chips = db.Chips.Find(id);
            if (chips == null)
            {
                return HttpNotFound();
            }
            return View(chips);
        }

        // POST: Chips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chips chips = db.Chips.Find(id);
            db.Chips.Remove(chips);
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
