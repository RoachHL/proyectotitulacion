using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sisetitulacion.Models;

namespace sisetitulacion.Controllers
{
    public class TBL_TipoEquipoController : Controller
    {
        private Model db = new Model();

        // GET: TBL_TipoEquipo
        public async Task<ActionResult> Index()
        {
            return View(await db.TBL_TipoEquipo.ToListAsync());
        }

        // GET: TBL_TipoEquipo/Details/5
        public async Task<ActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_TipoEquipo tBL_TipoEquipo = await db.TBL_TipoEquipo.FindAsync(id);
            if (tBL_TipoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(tBL_TipoEquipo);
        }

        // GET: TBL_TipoEquipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_TipoEquipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_TipoEquipo,nombreTipoEquipo,abreviatura")] TBL_TipoEquipo tBL_TipoEquipo)
        {
            if (ModelState.IsValid)
            {
                db.TBL_TipoEquipo.Add(tBL_TipoEquipo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tBL_TipoEquipo);
        }

        // GET: TBL_TipoEquipo/Edit/5
        public async Task<ActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_TipoEquipo tBL_TipoEquipo = await db.TBL_TipoEquipo.FindAsync(id);
            if (tBL_TipoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(tBL_TipoEquipo);
        }

        // POST: TBL_TipoEquipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_TipoEquipo,nombreTipoEquipo,abreviatura")] TBL_TipoEquipo tBL_TipoEquipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_TipoEquipo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tBL_TipoEquipo);
        }

        // GET: TBL_TipoEquipo/Delete/5
        public async Task<ActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_TipoEquipo tBL_TipoEquipo = await db.TBL_TipoEquipo.FindAsync(id);
            if (tBL_TipoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(tBL_TipoEquipo);
        }

        // POST: TBL_TipoEquipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(byte id)
        {
            TBL_TipoEquipo tBL_TipoEquipo = await db.TBL_TipoEquipo.FindAsync(id);
            db.TBL_TipoEquipo.Remove(tBL_TipoEquipo);
            await db.SaveChangesAsync();
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
