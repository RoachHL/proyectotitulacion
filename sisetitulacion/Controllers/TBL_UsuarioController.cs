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
    public class TBL_UsuarioController : Controller
    {
        private Model db = new Model();

        // GET: TBL_Usuario
        public async Task<ActionResult> Index()
        {
            var tBL_Usuario = db.TBL_Usuario.Include(t => t.TBL_tipoUsuario);
            return View(await tBL_Usuario.ToListAsync());
        }

        // GET: TBL_Usuario/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Usuario tBL_Usuario = await db.TBL_Usuario.FindAsync(id);
            if (tBL_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Usuario);
        }

        // GET: TBL_Usuario/Create
        public ActionResult Create()
        {
            ViewBag.TipoUsuario = new SelectList(db.TBL_tipoUsuario, "Id_TipoUsuario", "nombretitpousario");
            return View();
        }

        // POST: TBL_Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_usuario,TipoUsuario,nombresuario,contrasenha")] TBL_Usuario tBL_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Usuario.Add(tBL_Usuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TipoUsuario = new SelectList(db.TBL_tipoUsuario, "Id_TipoUsuario", "nombretitpousario", tBL_Usuario.TipoUsuario);
            return View(tBL_Usuario);
        }

        // GET: TBL_Usuario/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Usuario tBL_Usuario = await db.TBL_Usuario.FindAsync(id);
            if (tBL_Usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoUsuario = new SelectList(db.TBL_tipoUsuario, "Id_TipoUsuario", "nombretitpousario", tBL_Usuario.TipoUsuario);
            return View(tBL_Usuario);
        }

        // POST: TBL_Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_usuario,TipoUsuario,nombresuario,contrasenha")] TBL_Usuario tBL_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Usuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TipoUsuario = new SelectList(db.TBL_tipoUsuario, "Id_TipoUsuario", "nombretitpousario", tBL_Usuario.TipoUsuario);
            return View(tBL_Usuario);
        }

        // GET: TBL_Usuario/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Usuario tBL_Usuario = await db.TBL_Usuario.FindAsync(id);
            if (tBL_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Usuario);
        }

        // POST: TBL_Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            TBL_Usuario tBL_Usuario = await db.TBL_Usuario.FindAsync(id);
            db.TBL_Usuario.Remove(tBL_Usuario);
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
