﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhysicianApplication.Service;
using System.Net;
using System.Net.Http;
using PhysicianApplication.Models;


namespace PhysicianApplication.Controllers
{
    public class HomeController : Controller
    {
        DataFetchContext context;
        PhysicianViewService physicianViewService;
        PhysicianDeleteService physicianDeleteService;

        public ActionResult Index()
        {
            physicianViewService = new PhysicianViewService();
            var dataToView = physicianViewService.ViewAllPhysicians();
            return View(dataToView);
        }
        public ActionResult Delete(Guid id)
        {
            physicianDeleteService = new PhysicianDeleteService();
            physicianDeleteService.DeleteForID(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            context = new DataFetchContext();
            var toEditRecord = context.Physicians.Single(x => x.ID == id);
            ViewBag.HospitalRecord = context.Hospitals;
            ViewBag.SpecialtyRecord = context.Specialties;
            return View("Form", toEditRecord);
        }

        [HttpPost]
        public ActionResult Edit(Physician a)
        {
            
            if (ModelState.IsValid)
            {
                using (context = new DataFetchContext())
                {
                    context.Physicians.Attach(a);
                    context.Entry<Physician>(a).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                context = new DataFetchContext();
                ViewBag.HospitalRecord = context.Hospitals;
                ViewBag.SpecialtyRecord = context.Specialties;
                return View("Form", a);
                
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            var context = new DataFetchContext();
            ViewBag.HospitalRecord = context.Hospitals;
            ViewBag.SpecialtyRecord = context.Specialties;
            return View("Form");
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ID")] Physician a)
        {
           
            if (ModelState.IsValid)
            {        
                using (context = new DataFetchContext())
                {
                    a.ID = Guid.NewGuid();
                    context.Physicians.Add(a);
                    context.Entry<Physician>(a).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                context = new DataFetchContext();
                ViewBag.HospitalRecord = context.Hospitals;
                ViewBag.SpecialtyRecord = context.Specialties;
                return View("Form", a);
            }
        }
    }
}
