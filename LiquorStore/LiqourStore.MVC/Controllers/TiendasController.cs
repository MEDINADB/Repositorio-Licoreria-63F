﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LiqourStore.Entities.IRepositories;
using LiqourStore.Entities;
using LiqourStore.Persistence;

namespace LiqourStore.MVC.Controllers
{
    public class TiendasController : Controller
    {
        //  private LiqourStoreDbContext db = new LiqourStoreDbContext();
        private readonly IUnityofWork _UnityOfWork;

        public TiendasController(IUnityofWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public TiendasController()
        {

        }

        // GET: Tiendas
        public ActionResult Index()
        {
            // return View(db.Tiendas.ToList());
            return View(_UnityOfWork.Tienda.GetAll());

        }

        // GET: Tiendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Tienda tienda = db.Tiendas.Find(id);
            Tienda tienda = _UnityOfWork.Tienda.Get(id);

            if (tienda == null)
            {
                return HttpNotFound();
            }
            return View(tienda);
        }

        // GET: Tiendas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tiendas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TiendaId,DireccionTienda")] Tienda tienda)
        {
            if (ModelState.IsValid)
            {
                // db.Tiendas.Add(tienda);
                _UnityOfWork.Tienda.Add(tienda);

                //  db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(tienda);
        }

        // GET: Tiendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //   Tienda tienda = db.Tiendas.Find(id);
            Tienda tienda = _UnityOfWork.Tienda.Get(id);

            if (tienda == null)
            {
                return HttpNotFound();
            }
            return View(tienda);
        }

        // POST: Tiendas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TiendaId,DireccionTienda")] Tienda tienda)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(tienda).State = EntityState.Modified;
                _UnityOfWork.StateModified(tienda);

                // db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(tienda);
        }

        // GET: Tiendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Tienda tienda = db.Tiendas.Find(id);
            Tienda tienda = _UnityOfWork.Tienda.Get(id);

            if (tienda == null)
            {
                return HttpNotFound();
            }
            return View(tienda);
        }

        // POST: Tiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //  Tienda tienda = db.Tiendas.Find(id);
            Tienda tienda = _UnityOfWork.Tienda.Get(id);

            //  db.Tiendas.Remove(tienda);

            _UnityOfWork.Tienda.Delete(tienda);

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
