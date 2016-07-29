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
    public class HistoricosController : Controller
    {
        private CAVA db = new CAVA();

        // GET: Historicos
        public ActionResult Index()
        {
            var historicos = db.Historicos.Include(h => h.Ativos).Include(h => h.Celulares).Include(h => h.Chips).Include(h => h.Chips1).Include(h => h.Colaboradores).Include(h => h.Colaboradores1).Include(h => h.Colaboradores2).Include(h => h.Computadores);
            return View(historicos.ToList());
        }

        // GET: Historicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historicos historicos = db.Historicos.Find(id);
            if (historicos == null)
            {
                return HttpNotFound();
            }
            return View(historicos);
        }

        // GET: Historicos/Create
        public ActionResult Create()
        {
            ViewBag.AtivoId = new SelectList(db.Ativos, "Id", "Id");
            ViewBag.CelularId = new SelectList(db.Celulares, "Id", "Id");
            ViewBag.ChipId = new SelectList(db.Chips, "Id", "Id");
            ViewBag.ColaboradorIdFinal = new SelectList(db.Chips, "Id", "Id");
            ViewBag.ColaboradorIdFinal = new SelectList(db.Colaboradores, "Id", "Id");
            ViewBag.IntermediarioIdRecebeu = new SelectList(db.Colaboradores, "Id", "Id");
            ViewBag.IntermediarioIdAssinouTermo = new SelectList(db.Colaboradores, "Id", "Id");
            ViewBag.ComputadorId = new SelectList(db.Computadores, "Id", "Id");
            return View();
        }

        // POST: Historicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CelularId,ComputadorId,ChipId,AtivoId,ColaboradorIdFinal,AssinouTermoEntrega,AssinouTermoDevolucao,DataUserInicio,DataUserFinal,IntermediarioIdAssinouTermo,DataIntermediarioRetirou,IntermediarioIdRecebeu,DataIntermediarioIdRecebeu,Obs,DataFinalExperiencia")] Historicos historicos)
        {
            if (ModelState.IsValid)
            {
                db.Historicos.Add(historicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AtivoId = new SelectList(db.Ativos, "Id", "NumeroSerie", historicos.AtivoId);
            //ViewBag.CelularId = new SelectList(db.Celulares, "Id", "Modelo", historicos.CelularId);
            //ViewBag.ChipId = new SelectList(db.Chips, "Id", "NumeroChip", historicos.ChipId);
            ViewBag.ColaboradorIdFinal = new SelectList(db.Chips, "Id", "NumeroChip", historicos.ColaboradorIdFinal);
            ViewBag.ColaboradorIdFinal = new SelectList(db.Colaboradores, "Id", "CPF", historicos.ColaboradorIdFinal);
            ViewBag.IntermediarioIdRecebeu = new SelectList(db.Colaboradores, "Id", "CPF", historicos.IntermediarioIdRecebeu);
            ViewBag.IntermediarioIdAssinouTermo = new SelectList(db.Colaboradores, "Id", "CPF", historicos.IntermediarioIdAssinouTermo);
            //ViewBag.ComputadorId = new SelectList(db.Computadores, "Id", "ServiceTag", historicos.ComputadorId);
            return View(historicos);
        }

        // GET: Historicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historicos historicos = db.Historicos.Find(id);
            if (historicos == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtivoId = new SelectList(db.Ativos, "Id", "NumeroSerie", historicos.AtivoId);
            //ViewBag.CelularId = new SelectList(db.Celulares, "Id", "Modelo", historicos.CelularId);
            //ViewBag.ChipId = new SelectList(db.Chips, "Id", "NumeroChip", historicos.ChipId);
            ViewBag.ColaboradorIdFinal = new SelectList(db.Chips, "Id", "NumeroChip", historicos.ColaboradorIdFinal);
            ViewBag.ColaboradorIdFinal = new SelectList(db.Colaboradores, "Id", "CPF", historicos.ColaboradorIdFinal);
            ViewBag.IntermediarioIdRecebeu = new SelectList(db.Colaboradores, "Id", "CPF", historicos.IntermediarioIdRecebeu);
            ViewBag.IntermediarioIdAssinouTermo = new SelectList(db.Colaboradores, "Id", "CPF", historicos.IntermediarioIdAssinouTermo);
            //ViewBag.ComputadorId = new SelectList(db.Computadores, "Id", "ServiceTag", historicos.ComputadorId);
            return View(historicos);
        }

        // POST: Historicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CelularId,ComputadorId,ChipId,AtivoId,ColaboradorIdFinal,AssinouTermoEntrega,AssinouTermoDevolucao,DataUserInicio,DataUserFinal,IntermediarioIdAssinouTermo,DataIntermediarioRetirou,IntermediarioIdRecebeu,DataIntermediarioIdRecebeu,Obs,DataFinalExperiencia")] Historicos historicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AtivoId = new SelectList(db.Ativos, "Id", "NumeroSerie", historicos.AtivoId);
            //ViewBag.CelularId = new SelectList(db.Celulares, "Id", "Modelo", historicos.CelularId);
            //ViewBag.ChipId = new SelectList(db.Chips, "Id", "NumeroChip", historicos.ChipId);
            ViewBag.ColaboradorIdFinal = new SelectList(db.Chips, "Id", "NumeroChip", historicos.ColaboradorIdFinal);
            ViewBag.ColaboradorIdFinal = new SelectList(db.Colaboradores, "Id", "CPF", historicos.ColaboradorIdFinal);
            ViewBag.IntermediarioIdRecebeu = new SelectList(db.Colaboradores, "Id", "CPF", historicos.IntermediarioIdRecebeu);
            ViewBag.IntermediarioIdAssinouTermo = new SelectList(db.Colaboradores, "Id", "CPF", historicos.IntermediarioIdAssinouTermo);
            //ViewBag.ComputadorId = new SelectList(db.Computadores, "Id", "ServiceTag", historicos.ComputadorId);
            return View(historicos);
        }

        // GET: Historicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historicos historicos = db.Historicos.Find(id);
            if (historicos == null)
            {
                return HttpNotFound();
            }
            return View(historicos);
        }

        // POST: Historicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historicos historicos = db.Historicos.Find(id);
            db.Historicos.Remove(historicos);
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
