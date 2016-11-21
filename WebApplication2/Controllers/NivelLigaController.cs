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
    public class NivelLigaController : Controller
    {
        private App1Entities db = new App1Entities();

        // GET: NivelLiga
        public ActionResult Index()
        {
            return View(db.TBL_NivelLiga.ToList());
        }

        // GET: NivelLiga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_NivelLiga tBL_NivelLiga = db.TBL_NivelLiga.Find(id);
            if (tBL_NivelLiga == null)
            {
                return HttpNotFound();
            }
            return View(tBL_NivelLiga);
        }

        // GET: NivelLiga/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NivelLiga/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdNivelLiga,NivelLiga")] TBL_NivelLiga tBL_NivelLiga)
        {
            if (ModelState.IsValid)
            {
                db.TBL_NivelLiga.Add(tBL_NivelLiga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_NivelLiga);
        }

        // GET: NivelLiga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_NivelLiga tBL_NivelLiga = db.TBL_NivelLiga.Find(id);
            if (tBL_NivelLiga == null)
            {
                return HttpNotFound();
            }
            return View(tBL_NivelLiga);
        }

        // POST: NivelLiga/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdNivelLiga,NivelLiga")] TBL_NivelLiga tBL_NivelLiga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_NivelLiga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_NivelLiga);
        }

        // GET: NivelLiga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_NivelLiga tBL_NivelLiga = db.TBL_NivelLiga.Find(id);
            if (tBL_NivelLiga == null)
            {
                return HttpNotFound();
            }
            return View(tBL_NivelLiga);
        }

        // POST: NivelLiga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_NivelLiga tBL_NivelLiga = db.TBL_NivelLiga.Find(id);
            db.TBL_NivelLiga.Remove(tBL_NivelLiga);
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
