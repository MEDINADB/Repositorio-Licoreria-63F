﻿using System;
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
    public class EmpleadosController : Controller
    {
        //private LiqourStoreDbContext db = new LiqourStoreDbContext();

        private readonly IUnityofWork _UnityOfWork;

        public EmpleadosController(IUnityofWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public EmpleadosController()
        {

        }


        // GET: Empleados
        public ActionResult Index()
        {
            // return View(db.Empleados.ToList());
            return View(_UnityOfWork.Empleado.GetAll());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ///  Empleado empleado = db.Empleados.Find(id);
            Empleado empleado = _UnityOfWork.Empleado.Get(id);

            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpleadoId,Nombres,ApePaterno,ApeMaterno,Telefono,Sexo,FechaIngreso,Estado,Direccion,Correo")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                // db.Empleados.Add(empleado);
                _UnityOfWork.Empleado.Add(empleado);

                // db.SaveChanges();
                _UnityOfWork.SaveChanges();


                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Empleado empleado = db.Empleados.Find(id);
            Empleado empleado = _UnityOfWork.Empleado.Get(id);

            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpleadoId,Nombres,ApePaterno,ApeMaterno,Telefono,Sexo,FechaIngreso,Estado,Direccion,Correo")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(empleado).State = EntityState.Modified;
                _UnityOfWork.StateModified(empleado);

                //  db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Empleado empleado = db.Empleados.Find(id);
            Empleado empleado = _UnityOfWork.Empleado.Get(id);

            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Empleado empleado = db.Empleados.Find(id);
            Empleado emopleado = _UnityOfWork.Empleado.Get(id);

            //  db.Empleados.Remove(empleado);
            _UnityOfWork.Empleado.Delete(emopleado);

            // db.SaveChanges();
            _UnityOfWork.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //  db.Dispose();
                _UnityOfWork.Dispose();

            }
            base.Dispose(disposing);
        }
    }
}
