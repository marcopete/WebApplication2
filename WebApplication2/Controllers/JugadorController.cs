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
    public class JugadorController : Controller
    {
        private App1Entities db = new App1Entities();

        // GET: Jugador
        public ActionResult Index()
        {
            var tBL_Jugador = db.TBL_Jugador.Include(t => t.TBL_Equipo);
            return View(tBL_Jugador.ToList());
        }

        // GET: Jugador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Jugador tBL_Jugador = db.TBL_Jugador.Find(id);
            if (tBL_Jugador == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Jugador);
        }

        // GET: Jugador/Create
        public ActionResult Create()
        {
            ViewBag.IdEquipo = new SelectList(db.TBL_Equipo, "IdEquipo", "NombreEquipo");
            return View();
        }

        // POST: Jugador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdJugador,NombreJugador,IdEquipo,Goles")] TBL_Jugador tBL_Jugador)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Jugador.Add(tBL_Jugador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEquipo = new SelectList(db.TBL_Equipo, "IdEquipo", "NombreEquipo", tBL_Jugador.IdEquipo);
            return View(tBL_Jugador);
        }

        // GET: Jugador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Jugador tBL_Jugador = db.TBL_Jugador.Find(id);
            if (tBL_Jugador == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEquipo = new SelectList(db.TBL_Equipo, "IdEquipo", "NombreEquipo", tBL_Jugador.IdEquipo);
            return View(tBL_Jugador);
        }

        // POST: Jugador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdJugador,NombreJugador,IdEquipo,Goles")] TBL_Jugador tBL_Jugador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Jugador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEquipo = new SelectList(db.TBL_Equipo, "IdEquipo", "NombreEquipo", tBL_Jugador.IdEquipo);
            return View(tBL_Jugador);
        }

        // GET: Jugador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Jugador tBL_Jugador = db.TBL_Jugador.Find(id);
            if (tBL_Jugador == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Jugador);
        }

        // POST: Jugador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Jugador tBL_Jugador = db.TBL_Jugador.Find(id);
            db.TBL_Jugador.Remove(tBL_Jugador);
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
