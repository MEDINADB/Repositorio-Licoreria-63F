using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LiqourStore.Entities;
using LiqourStore.Entities.IRepositories;
using LiqourStore.Persistence;

namespace LiqourStore.MVC.Controllers
{
    public class ComprasController : Controller
    {
        //private LiqourStoreDbContext db = new LiqourStoreDbContext();
        private readonly IUnityofWork _UnityOfWork;

        public ComprasController(IUnityofWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public ComprasController()
        {

        }

        // GET: Compras
        public ActionResult Index()
        {
            // return View(db.Compras.ToList());
            return View(_UnityOfWork.Compra.GetAll());

        }

        // GET: Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  Compra compra = db.Compras.Find(id);
            Compra compra = _UnityOfWork.Compra.Get(id);

            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompraId,DescripcionCompra")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                //db.Compras.Add(compra);
                _UnityOfWork.Compra.Add(compra);

                // db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(compra);
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Compra compra = db.Compras.Find(id);
            Compra compra = _UnityOfWork.Compra.Get(id);

            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompraId,DescripcionCompra")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(compra).State = EntityState.Modified;
                _UnityOfWork.StateModified(compra);

                //  db.SaveChanges();
                    _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(compra);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Compra compra = db.Compras.Find(id);
            Compra compra = _UnityOfWork.Compra.Get(id);

            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Compra compra = db.Compras.Find(id);
            Compra compra = _UnityOfWork.Compra.Get(id);

            // db.Compras.Remove(compra);
            _UnityOfWork.Compra.Delete(compra);

            //db.SaveChanges();
            _UnityOfWork.SaveChanges();


            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
                _UnityOfWork.Dispose();

            }
            base.Dispose(disposing);
        }
    }
}
