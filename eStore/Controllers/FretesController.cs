using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eStore.Entities;
using eStore.Entities.Context;

namespace eStore.Controllers
{
    public class FretesController : Controller
    {
        private eStoreContext db = new eStoreContext();

        // GET: Fretes
        public async Task<ActionResult> Index()
        {
            return View(await db.Frete.ToListAsync());
        }

        // GET: Fretes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frete frete = await db.Frete.FindAsync(id);
            if (frete == null)
            {
                return HttpNotFound();
            }
            return View(frete);
        }

        // GET: Fretes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fretes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nome,tipo,ordem,status")] Frete frete)
        {
            if (ModelState.IsValid)
            {
                db.Frete.Add(frete);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(frete);
        }

        // GET: Fretes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frete frete = await db.Frete.FindAsync(id);
            if (frete == null)
            {
                return HttpNotFound();
            }
            return View(frete);
        }

        // POST: Fretes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nome,tipo,ordem,status")] Frete frete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frete).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(frete);
        }

        // GET: Fretes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frete frete = await db.Frete.FindAsync(id);
            if (frete == null)
            {
                return HttpNotFound();
            }
            return View(frete);
        }

        // POST: Fretes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Frete frete = await db.Frete.FindAsync(id);
            db.Frete.Remove(frete);
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
