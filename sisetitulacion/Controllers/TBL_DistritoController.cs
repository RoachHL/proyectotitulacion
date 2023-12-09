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
    public class TBL_DistritoController : Controller
    {
        private Model db = new Model();

        // GET: TBL_Distrito
        public async Task<ActionResult> Index()
        {
            return View(await db.TBL_Distrito.ToListAsync());
        }

        // GET: TBL_Distrito/Details/5
        public async Task<ActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Distrito tBL_Distrito = await db.TBL_Distrito.FindAsync(id);
            if (tBL_Distrito == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Distrito);
        }

        // GET: TBL_Distrito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_Distrito/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_Distrito,nombre_Disrito")] TBL_Distrito tBL_Distrito)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Distrito.Add(tBL_Distrito);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tBL_Distrito);
        }

        // GET: TBL_Distrito/Edit/5
        public async Task<ActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Distrito tBL_Distrito = await db.TBL_Distrito.FindAsync(id);
            if (tBL_Distrito == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Distrito);
        }

        // POST: TBL_Distrito/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_Distrito,nombre_Disrito")] TBL_Distrito tBL_Distrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Distrito).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tBL_Distrito);
        }

        // GET: TBL_Distrito/Delete/5
        public async Task<ActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Distrito tBL_Distrito = await db.TBL_Distrito.FindAsync(id);
            if (tBL_Distrito == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Distrito);
        }

        // POST: TBL_Distrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(byte id)
        {
            TBL_Distrito tBL_Distrito = await db.TBL_Distrito.FindAsync(id);
            db.TBL_Distrito.Remove(tBL_Distrito);
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
