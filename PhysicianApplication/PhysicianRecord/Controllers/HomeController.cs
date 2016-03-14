using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhysicianRecord.Models;

namespace PhysicianRecord.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DataFetchContext dataFetchContext = new DataFetchContext();
            IEnumerable<Hospital> hospitalRecord = dataFetchContext.Hospitals.ToList();
            IEnumerable<Specialty> specialtyRecord = dataFetchContext.Specialties.ToList();
            IEnumerable<Physician> physicianRecord = dataFetchContext.Physicians.ToList();
            List<DataToView> dataToView=new List<DataToView>();
            foreach (Physician p in physicianRecord)
            {
               
                DataToView physicianDataToView= new DataToView();
                physicianDataToView.Age = p.Age;
                physicianDataToView.Name = p.Name;
                physicianDataToView.NPI = p.NPI;
                physicianDataToView.ID = p.ID;
                physicianDataToView.ConsultationCharge = p.ConsultationCharge;
                physicianDataToView.Specialty = specialtyRecord.First(rec => rec.SpecialtyID == p.SpecialtyID).SpecialtyName.ToString();
                physicianDataToView.Hospital = hospitalRecord.Single(rec => rec.HospitalID == p.HospitalID).HospitalName;
                dataToView.Add(physicianDataToView);
               
            }

            return View(dataToView);
        }
    }
}