using PhysicianApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhysicianApplication.Service;
using System.Net;
using System.Net.Http;

namespace PhysicianApplication.Controllers
{
    public class HomeController : Controller
    {
        private TableToViewMapService tableToViewMapService = new TableToViewMapService();
        private IEnumerable<DataToView> dataToView;
        

        public ActionResult Index()
        {
            dataToView = tableToViewMapService.GetFullRecord();
            return View(dataToView);
        }
        public ActionResult Delete(Guid id)
        {
            DeleteService deleteEntry = new DeleteService();
            deleteEntry.DeleteForID(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            DataFetchContext dataFetchContext = new DataFetchContext();
            var toEditRecord = dataFetchContext.Physicians.Single(x => x.ID == id);
            ViewBag.HospitalRecord = dataFetchContext.Hospitals;
            ViewBag.SpecialtyRecord = dataFetchContext.Specialties;
            return View("Form", toEditRecord);
        }

        [HttpPost]
        public ActionResult Edit(Physician a)
        {
            using (var context = new DataFetchContext())
            {
                if(ModelState.IsValid)
                {
                    context.Physicians.Attach(a);
                    context.Entry<Physician>(a).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    DataFetchContext dataFetchContext = new DataFetchContext();
                    ViewBag.HospitalRecord = dataFetchContext.Hospitals;
                    ViewBag.SpecialtyRecord = dataFetchContext.Specialties;
                    return View("Form", a);
                }
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            DataFetchContext dataFetchContext = new DataFetchContext();
            ViewBag.HospitalRecord = dataFetchContext.Hospitals;
            ViewBag.SpecialtyRecord = dataFetchContext.Specialties;
            return View("Form",new Physician());
        }

        [HttpPost]
        public ActionResult Create(Physician a)
        {
            using (var context = new DataFetchContext())
            {
                if (ModelState.IsValid)
                {
                    a.ID = Guid.NewGuid();
                    context.Physicians.Add(a);
                    context.Entry<Physician>(a).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    DataFetchContext dataFetchContext = new DataFetchContext();
                    ViewBag.HospitalRecord = dataFetchContext.Hospitals;
                    ViewBag.SpecialtyRecord = dataFetchContext.Specialties;
                    return View("Form", a);
                }
            } 
        }
    }
}
