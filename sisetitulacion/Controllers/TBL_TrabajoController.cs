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
    public class TBL_TrabajoController : Controller
    {
        private Model db = new Model();

        // GET: TBL_Trabajo
        public async Task<ActionResult> Index()
        {
            return View(await db.TBL_Trabajo.ToListAsync());
        }

        // GET: TBL_Trabajo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Trabajo tBL_Trabajo = await db.TBL_Trabajo.FindAsync(id);
            if (tBL_Trabajo == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Trabajo);
        }

        // GET: TBL_Trabajo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_Trabajo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idTrabajo,nombretrabajo,precio")] TBL_Trabajo tBL_Trabajo)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Trabajo.Add(tBL_Trabajo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tBL_Trabajo);
        }

        // GET: TBL_Trabajo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Trabajo tBL_Trabajo = await db.TBL_Trabajo.FindAsync(id);
            if (tBL_Trabajo == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Trabajo);
        }

        // POST: TBL_Trabajo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idTrabajo,nombretrabajo,precio")] TBL_Trabajo tBL_Trabajo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Trabajo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tBL_Trabajo);
        }

        // GET: TBL_Trabajo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Trabajo tBL_Trabajo = await db.TBL_Trabajo.FindAsync(id);
            if (tBL_Trabajo == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Trabajo);
        }

        // POST: TBL_Trabajo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TBL_Trabajo tBL_Trabajo = await db.TBL_Trabajo.FindAsync(id);
            db.TBL_Trabajo.Remove(tBL_Trabajo);
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
