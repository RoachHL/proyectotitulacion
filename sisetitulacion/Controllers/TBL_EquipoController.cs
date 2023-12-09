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
    public class TBL_EquipoController : Controller
    {
        private Model db = new Model();

        // GET: TBL_Equipo
        public async Task<ActionResult> Index()
        {
            var tBL_Equipo = db.TBL_Equipo.Include(t => t.TBL_Cliente).Include(t => t.TBL_Marca).Include(t => t.TBL_TipoEquipo);
            return View(await tBL_Equipo.ToListAsync());
        }

        // GET: TBL_Equipo/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Equipo tBL_Equipo = await db.TBL_Equipo.FindAsync(id);
            if (tBL_Equipo == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Equipo);
        }

        // GET: TBL_Equipo/Create
        public ActionResult Create()
        {
            ViewBag.Cliente = new SelectList(db.TBL_Cliente, "id_cliente", "Tipo_documento");
            ViewBag.marca = new SelectList(db.TBL_Marca, "Id_Marca", "nombreMarca");
            ViewBag.tipoequipo = new SelectList(db.TBL_TipoEquipo, "Id_TipoEquipo", "nombreTipoEquipo");
            return View();
        }

        // POST: TBL_Equipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idequipo,Cliente,tipoequipo,marca,modelo,numersoserie,observaciones")] TBL_Equipo tBL_Equipo)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Equipo.Add(tBL_Equipo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente = new SelectList(db.TBL_Cliente, "id_cliente", "Tipo_documento", tBL_Equipo.Cliente);
            ViewBag.marca = new SelectList(db.TBL_Marca, "Id_Marca", "nombreMarca", tBL_Equipo.marca);
            ViewBag.tipoequipo = new SelectList(db.TBL_TipoEquipo, "Id_TipoEquipo", "nombreTipoEquipo", tBL_Equipo.tipoequipo);
            return View(tBL_Equipo);
        }

        // GET: TBL_Equipo/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Equipo tBL_Equipo = await db.TBL_Equipo.FindAsync(id);
            if (tBL_Equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente = new SelectList(db.TBL_Cliente, "id_cliente", "Tipo_documento", tBL_Equipo.Cliente);
            ViewBag.marca = new SelectList(db.TBL_Marca, "Id_Marca", "nombreMarca", tBL_Equipo.marca);
            ViewBag.tipoequipo = new SelectList(db.TBL_TipoEquipo, "Id_TipoEquipo", "nombreTipoEquipo", tBL_Equipo.tipoequipo);
            return View(tBL_Equipo);
        }

        // POST: TBL_Equipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idequipo,Cliente,tipoequipo,marca,modelo,numersoserie,observaciones")] TBL_Equipo tBL_Equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Equipo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente = new SelectList(db.TBL_Cliente, "id_cliente", "Tipo_documento", tBL_Equipo.Cliente);
            ViewBag.marca = new SelectList(db.TBL_Marca, "Id_Marca", "nombreMarca", tBL_Equipo.marca);
            ViewBag.tipoequipo = new SelectList(db.TBL_TipoEquipo, "Id_TipoEquipo", "nombreTipoEquipo", tBL_Equipo.tipoequipo);
            return View(tBL_Equipo);
        }

        // GET: TBL_Equipo/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Equipo tBL_Equipo = await db.TBL_Equipo.FindAsync(id);
            if (tBL_Equipo == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Equipo);
        }

        // POST: TBL_Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            TBL_Equipo tBL_Equipo = await db.TBL_Equipo.FindAsync(id);
            db.TBL_Equipo.Remove(tBL_Equipo);
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
