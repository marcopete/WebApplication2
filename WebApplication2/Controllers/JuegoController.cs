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
    public class JuegoController : Controller
    {
        private App1Entities db = new App1Entities();

        // GET: Juego
        public ActionResult Index()
        {
            var tBL_Juego = db.TBL_Juego.Include(t => t.TBL_Equipo).Include(t => t.TBL_Equipo1).Include(t => t.TBL_Liga);
            return View(tBL_Juego.ToList());
        }

        // GET: Juego/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Juego tBL_Juego = db.TBL_Juego.Find(id);
            if (tBL_Juego == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Juego);
        }

        // GET: Juego/Create
        public ActionResult Create()
        {
            ViewBag.IdEquipoLocal = new SelectList(db.TBL_Equipo, "IdEquipo", "NombreEquipo");
            ViewBag.IdEquipoVisita = new SelectList(db.TBL_Equipo, "IdEquipo", "NombreEquipo");
            ViewBag.IdLiga = new SelectList(db.TBL_Liga, "IdLiga", "NombreLiga");
            return View();
        }

        // POST: Juego/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdJuego,IdLiga,IdEquipoLocal,IdEquipoVisita,GolesLocal,GolesVisita")] TBL_Juego tBL_Juego)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Juego.Add(tBL_Juego);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEquipoLocal = new SelectList(db.TBL_Equipo, "IdEquipo", "NombreEquipo", tBL_Juego.IdEquipoLocal);
            ViewBag.IdEquipoVisita = new SelectList(db.TBL_Equipo, "IdEquipo", "NombreEquipo", tBL_Juego.IdEquipoVisita);
            ViewBag.IdLiga = new SelectList(db.TBL_Liga, "IdLiga", "NombreLiga", tBL_Juego.IdLiga);
            return View(tBL_Juego);
        }

        // GET: Juego/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Juego tBL_Juego = db.TBL_Juego.Find(id);
            if (tBL_Juego == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEquipoLocal = new SelectList(db.TBL_Equipo, "IdEquipo", "NombreEquipo", tBL_Juego.IdEquipoLocal);
            ViewBag.IdEquipoVisita = new SelectList(db.TBL_Equipo, "IdEquipo", "NombreEquipo", tBL_Juego.IdEquipoVisita);
            ViewBag.IdLiga = new SelectList(db.TBL_Liga, "IdLiga", "NombreLiga", tBL_Juego.IdLiga);
            return View(tBL_Juego);
        }

        // POST: Juego/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdJuego,IdLiga,IdEquipoLocal,IdEquipoVisita,GolesLocal,GolesVisita")] TBL_Juego tBL_Juego)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Juego).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEquipoLocal = new SelectList(db.TBL_Equipo, "IdEquipo", "NombreEquipo", tBL_Juego.IdEquipoLocal);
            ViewBag.IdEquipoVisita = new SelectList(db.TBL_Equipo, "IdEquipo", "NombreEquipo", tBL_Juego.IdEquipoVisita);
            ViewBag.IdLiga = new SelectList(db.TBL_Liga, "IdLiga", "NombreLiga", tBL_Juego.IdLiga);
            return View(tBL_Juego);
        }

        // GET: Juego/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Juego tBL_Juego = db.TBL_Juego.Find(id);
            if (tBL_Juego == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Juego);
        }

        // POST: Juego/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Juego tBL_Juego = db.TBL_Juego.Find(id);
            db.TBL_Juego.Remove(tBL_Juego);
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
