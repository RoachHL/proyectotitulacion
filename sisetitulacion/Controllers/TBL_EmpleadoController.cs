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
    public class TBL_EmpleadoController : Controller
    {
        private Model db = new Model();

        // GET: TBL_Empleado
        public async Task<ActionResult> Index()
        {
            var tBL_Empleado = db.TBL_Empleado.Include(t => t.TBL_Distrito);
            return View(await tBL_Empleado.ToListAsync());
        }

        // GET: TBL_Empleado/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Empleado tBL_Empleado = await db.TBL_Empleado.FindAsync(id);
            if (tBL_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Empleado);
        }

        // GET: TBL_Empleado/Create
        public ActionResult Create()
        {
            ViewBag.Distrito = new SelectList(db.TBL_Distrito, "id_Distrito", "nombre_Disrito");
            return View();
        }

        // POST: TBL_Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "dni,apellidoPaterno,apellidoMaterno,nombres,Distrito,Direccion,telefono,celular,estado")] TBL_Empleado tBL_Empleado)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Empleado.Add(tBL_Empleado);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Distrito = new SelectList(db.TBL_Distrito, "id_Distrito", "nombre_Disrito", tBL_Empleado.Distrito);
            return View(tBL_Empleado);
        }

        // GET: TBL_Empleado/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Empleado tBL_Empleado = await db.TBL_Empleado.FindAsync(id);
            if (tBL_Empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Distrito = new SelectList(db.TBL_Distrito, "id_Distrito", "nombre_Disrito", tBL_Empleado.Distrito);
            return View(tBL_Empleado);
        }

        // POST: TBL_Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "dni,apellidoPaterno,apellidoMaterno,nombres,Distrito,Direccion,telefono,celular,estado")] TBL_Empleado tBL_Empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Empleado).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Distrito = new SelectList(db.TBL_Distrito, "id_Distrito", "nombre_Disrito", tBL_Empleado.Distrito);
            return View(tBL_Empleado);
        }

        // GET: TBL_Empleado/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Empleado tBL_Empleado = await db.TBL_Empleado.FindAsync(id);
            if (tBL_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Empleado);
        }

        // POST: TBL_Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            TBL_Empleado tBL_Empleado = await db.TBL_Empleado.FindAsync(id);
            db.TBL_Empleado.Remove(tBL_Empleado);
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
