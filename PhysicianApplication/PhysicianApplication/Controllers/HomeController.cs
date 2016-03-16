using PhysicianApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhysicianApplication.Service;

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
        public ActionResult Delete(int id)
        {
            using(var context=new DataFetchContext())
            {
                var PhysicianList = context.Physicians.ToList<Physician>();
                context.Physicians.Remove(PhysicianList.First(a=>a.ID==id));
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
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
                context.Physicians.Attach(a);
                context.Entry<Physician>(a).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
             return RedirectToAction("Index");
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
                a.ID = null;
                context.Physicians.Attach(a);
                context.Physicians.Remove(a);
                context.Entry<Physician>(a).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
