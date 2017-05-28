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
    public class ProductosController : Controller
    {
        //private LiqourStoreDbContext db = new LiqourStoreDbContext();
        private readonly IUnityofWork _UnityOfWork;

        public ProductosController(IUnityofWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public ProductosController()
        {

        }
        // GET: Productos
        public ActionResult Index()
        {
            //return View(db.Productos.ToList());
            return View(_UnityOfWork.Producto.GetAll());

        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Producto producto = db.Productos.Find(id);
            Producto producto = _UnityOfWork.Producto.Get(id);

            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductoId,NombreCliente,DescripcionProducto,StockProducto,TipoProducto")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                // db.Productos.Add(producto);
                _UnityOfWork.Producto.Add(producto);

                // db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Producto producto = db.Productos.Find(id);
            Producto producto = _UnityOfWork.Producto.Get(id);

            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductoId,NombreCliente,DescripcionProducto,StockProducto,TipoProducto")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(producto).State = EntityState.Modified;
                _UnityOfWork.StateModified(producto);

                //  db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Producto producto = db.Productos.Find(id);
            Producto producto = _UnityOfWork.Producto.Get(id);

            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //  Producto producto = db.Productos.Find(id);
            Producto producto = _UnityOfWork.Producto.Get(id);

            //  db.Productos.Remove(producto);
            _UnityOfWork.Producto.Delete(producto);

            //  db.SaveChanges();
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
