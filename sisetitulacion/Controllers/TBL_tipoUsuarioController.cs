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
    public class TBL_tipoUsuarioController : Controller
    {
        private Model db = new Model();

        // GET: TBL_tipoUsuario
        public async Task<ActionResult> Index()
        {
            return View(await db.TBL_tipoUsuario.ToListAsync());
        }

        // GET: TBL_tipoUsuario/Details/5
        public async Task<ActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_tipoUsuario tBL_tipoUsuario = await db.TBL_tipoUsuario.FindAsync(id);
            if (tBL_tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tBL_tipoUsuario);
        }

        // GET: TBL_tipoUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_tipoUsuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_TipoUsuario,nombretitpousario")] TBL_tipoUsuario tBL_tipoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.TBL_tipoUsuario.Add(tBL_tipoUsuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tBL_tipoUsuario);
        }

        // GET: TBL_tipoUsuario/Edit/5
        public async Task<ActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_tipoUsuario tBL_tipoUsuario = await db.TBL_tipoUsuario.FindAsync(id);
            if (tBL_tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tBL_tipoUsuario);
        }

        // POST: TBL_tipoUsuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_TipoUsuario,nombretitpousario")] TBL_tipoUsuario tBL_tipoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_tipoUsuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tBL_tipoUsuario);
        }

        // GET: TBL_tipoUsuario/Delete/5
        public async Task<ActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_tipoUsuario tBL_tipoUsuario = await db.TBL_tipoUsuario.FindAsync(id);
            if (tBL_tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tBL_tipoUsuario);
        }

        // POST: TBL_tipoUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(byte id)
        {
            TBL_tipoUsuario tBL_tipoUsuario = await db.TBL_tipoUsuario.FindAsync(id);
            db.TBL_tipoUsuario.Remove(tBL_tipoUsuario);
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
