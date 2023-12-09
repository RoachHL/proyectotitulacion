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
    public class TBL_ClienteController : Controller
    {
        private Model db = new Model();

        // GET: TBL_Cliente
        public async Task<ActionResult> Index()
        {
            var tBL_Cliente = db.TBL_Cliente.Include(t => t.TBL_Distrito);
            return View(await tBL_Cliente.ToListAsync());
        }

        // GET: TBL_Cliente/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Cliente tBL_Cliente = await db.TBL_Cliente.FindAsync(id);
            if (tBL_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Cliente);
        }

        // GET: TBL_Cliente/Create
        public ActionResult Create()
        {
            ViewBag.Distrito = new SelectList(db.TBL_Distrito, "id_Distrito", "nombre_Disrito");
            return View();
        }

        // POST: TBL_Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_cliente,Tipo_documento,Numero_Documento,Nombre_Cliente,Distrito,Direccion,telefono,celular")] TBL_Cliente tBL_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Cliente.Add(tBL_Cliente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Distrito = new SelectList(db.TBL_Distrito, "id_Distrito", "nombre_Disrito", tBL_Cliente.Distrito);
            return View(tBL_Cliente);
        }

        // GET: TBL_Cliente/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Cliente tBL_Cliente = await db.TBL_Cliente.FindAsync(id);
            if (tBL_Cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Distrito = new SelectList(db.TBL_Distrito, "id_Distrito", "nombre_Disrito", tBL_Cliente.Distrito);
            return View(tBL_Cliente);
        }

        // POST: TBL_Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_cliente,Tipo_documento,Numero_Documento,Nombre_Cliente,Distrito,Direccion,telefono,celular")] TBL_Cliente tBL_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Cliente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Distrito = new SelectList(db.TBL_Distrito, "id_Distrito", "nombre_Disrito", tBL_Cliente.Distrito);
            return View(tBL_Cliente);
        }

        // GET: TBL_Cliente/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Cliente tBL_Cliente = await db.TBL_Cliente.FindAsync(id);
            if (tBL_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Cliente);
        }

        // POST: TBL_Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            TBL_Cliente tBL_Cliente = await db.TBL_Cliente.FindAsync(id);
            db.TBL_Cliente.Remove(tBL_Cliente);
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
