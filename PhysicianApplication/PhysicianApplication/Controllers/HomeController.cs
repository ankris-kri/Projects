using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhysicianApplication.Service;
using System.Net;
using System.Net.Http;
using PhysicianApplication.Models;
using PhysicianApplication.DAL;


namespace PhysicianApplication.Controllers
{
    public class HomeController : Controller
    {
        DataFetchContext context;
        PhysicianViewService physicianViewService;
        PhysicianDeleteService physicianDeleteService;
        PhysicianEditService physicianEditService;

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
        public ActionResult Edit(Physician _physicianEntry)
        {
            
            if (ModelState.IsValid)
            {
                physicianEditService = new PhysicianEditService();
                physicianEditService.Edit(_physicianEntry);
                return RedirectToAction("Index");
            }
            else
            {
                context = new DataFetchContext();
                ViewBag.HospitalRecord = context.Hospitals;
                ViewBag.SpecialtyRecord = context.Specialties;
                return View("Form", _physicianEntry);
               
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
        public ActionResult Create([Bind(Exclude = "ID")] Physician _physicianEntry)
        {
           
            if (ModelState.IsValid)
            {
                physicianEditService = new PhysicianEditService();
                physicianEditService.Create(_physicianEntry);
                return RedirectToAction("Index");
            }
            else
            {
                context = new DataFetchContext();
                ViewBag.HospitalRecord = context.Hospitals;
                ViewBag.SpecialtyRecord = context.Specialties;
                return View("Form", _physicianEntry);
            }
        }
    }
}
