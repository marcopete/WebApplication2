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
    public class LigaController : Controller
    {
        private App1Entities db = new App1Entities();

        // GET: Liga
        public ActionResult Index()
        {
            var tBL_Liga = db.TBL_Liga.Include(t => t.TBL_NivelLiga);
            return View(tBL_Liga.ToList());
        }

        // GET: Liga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Liga tBL_Liga = db.TBL_Liga.Find(id);
            if (tBL_Liga == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Liga);
        }

        // GET: Liga/Create
        public ActionResult Create()
        {
            ViewBag.IdNivelLiga = new SelectList(db.TBL_NivelLiga, "IdNivelLiga", "NivelLiga");
            return View();
        }

        // POST: Liga/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLiga,NombreLiga,IdNivelLiga,PremioLiga,DescripcionLiga,FechaInicio,FechaFin")] TBL_Liga tBL_Liga)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Liga.Add(tBL_Liga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdNivelLiga = new SelectList(db.TBL_NivelLiga, "IdNivelLiga", "NivelLiga", tBL_Liga.IdNivelLiga);
            return View(tBL_Liga);
        }

        // GET: Liga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Liga tBL_Liga = db.TBL_Liga.Find(id);
            if (tBL_Liga == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdNivelLiga = new SelectList(db.TBL_NivelLiga, "IdNivelLiga", "NivelLiga", tBL_Liga.IdNivelLiga);
            return View(tBL_Liga);
        }

        // POST: Liga/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLiga,NombreLiga,IdNivelLiga,PremioLiga,DescripcionLiga,FechaInicio,FechaFin")] TBL_Liga tBL_Liga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Liga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdNivelLiga = new SelectList(db.TBL_NivelLiga, "IdNivelLiga", "NivelLiga", tBL_Liga.IdNivelLiga);
            return View(tBL_Liga);
        }

        // GET: Liga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Liga tBL_Liga = db.TBL_Liga.Find(id);
            if (tBL_Liga == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Liga);
        }

        // POST: Liga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Liga tBL_Liga = db.TBL_Liga.Find(id);
            db.TBL_Liga.Remove(tBL_Liga);
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
