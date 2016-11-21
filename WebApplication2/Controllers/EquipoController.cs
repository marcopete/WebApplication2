using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Datos;

namespace WebApplication2.Controllers
{
    public class EquipoController : Controller
    {
        private App1Entities db = new App1Entities();

        // GET: Equipo
        public ActionResult Index()
        {
            var tBL_Equipo = db.TBL_Equipo.Include(t => t.TBL_Liga);
            return View(tBL_Equipo.ToList());
        }

        // GET: Equipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Equipo tBL_Equipo = db.TBL_Equipo.Find(id);
            if (tBL_Equipo == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Equipo);
        }

        // GET: Equipo/Create
        public ActionResult Create()
        {
            ViewBag.IdLiga = new SelectList(db.TBL_Liga, "IdLiga", "NombreLiga");
            return View();
        }

        // POST: Equipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEquipo,NombreEquipo,FechaFundacion,IdLiga")] TBL_Equipo tBL_Equipo)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Equipo.Add(tBL_Equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLiga = new SelectList(db.TBL_Liga, "IdLiga", "NombreLiga", tBL_Equipo.IdLiga);
            return View(tBL_Equipo);
        }

        // GET: Equipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Equipo tBL_Equipo = db.TBL_Equipo.Find(id);
            if (tBL_Equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLiga = new SelectList(db.TBL_Liga, "IdLiga", "NombreLiga", tBL_Equipo.IdLiga);
            return View(tBL_Equipo);
        }

        // POST: Equipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEquipo,NombreEquipo,FechaFundacion,IdLiga")] TBL_Equipo tBL_Equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Equipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLiga = new SelectList(db.TBL_Liga, "IdLiga", "NombreLiga", tBL_Equipo.IdLiga);
            return View(tBL_Equipo);
        }

        // GET: Equipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Equipo tBL_Equipo = db.TBL_Equipo.Find(id);
            if (tBL_Equipo == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Equipo);
        }

        // POST: Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Equipo tBL_Equipo = db.TBL_Equipo.Find(id);
            db.TBL_Equipo.Remove(tBL_Equipo);
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
