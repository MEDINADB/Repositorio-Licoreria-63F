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
    public class MarcasController : Controller
    {
        //  private LiqourStoreDbContext db = new LiqourStoreDbContext();
        private readonly IUnityofWork _UnityOfWork;

        public MarcasController(IUnityofWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public MarcasController()
        {

        }

        // GET: Marcas
        public ActionResult Index()
        {
            // return View(db.Marcas.ToList());
            return View(_UnityOfWork.Marca.GetAll());
        }

        // GET: Marcas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Marca marca = db.Marcas.Find(id);
            Marca marca = _UnityOfWork.Marca.Get(id);

            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // GET: Marcas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marcas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarcaId,NombreMarca,LogoMarca")] Marca marca)
        {
            if (ModelState.IsValid)
            {
                // db.Marcas.Add(marca);
                _UnityOfWork.Marca.Add(marca);

                //  db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(marca);
        }

        // GET: Marcas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Marca marca = db.Marcas.Find(id);
            Marca marca = _UnityOfWork.Marca.Get(id);

            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // POST: Marcas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarcaId,NombreMarca,LogoMarca")] Marca marca)
        {
            if (ModelState.IsValid)
            {
                //  db.Entry(marca).State = EntityState.Modified;
                _UnityOfWork.StateModified(marca);

                // db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(marca);
        }

        // GET: Marcas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Marca marca = db.Marcas.Find(id);
            Marca marca = _UnityOfWork.Marca.Get(id);

            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //  Marca marca = db.Marcas.Find(id);
            Marca marca = _UnityOfWork.Marca.Get(id);

            //  db.Marcas.Remove(marca);
            _UnityOfWork.Marca.Delete(marca);

            //  db.SaveChanges();

            _UnityOfWork.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
