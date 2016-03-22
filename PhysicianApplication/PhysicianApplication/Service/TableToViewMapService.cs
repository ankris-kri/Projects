using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhysicianApplication.Models;
namespace PhysicianApplication.Service
{
    public class TableToViewMapService
    {
        public DataFetchContext dataFetchContext { get; set; }
        public IEnumerable<Hospital> hospitalRecord { get; set; }
        public IEnumerable<Specialty> specialtyRecord { get; set; }
        public IEnumerable<Physician> physicianRecord { get; set; }
        public List<DataToView> dataToView { get; set; }

        public IEnumerable<DataToView> GetFullRecord()
        {
            dataFetchContext = new DataFetchContext();
            hospitalRecord = dataFetchContext.Hospitals.ToList();
            specialtyRecord = dataFetchContext.Specialties.ToList();
            physicianRecord = dataFetchContext.Physicians.ToList();
            dataToView = new List<DataToView>();
            foreach (Physician p in physicianRecord)
            {

                DataToView physicianDataToView = new DataToView();
                physicianDataToView.Age = p.Age;
                physicianDataToView.Name = p.Name;
                physicianDataToView.NPI = p.NPI;
                physicianDataToView.ID = p.ID;
                physicianDataToView.ConsultationCharge = p.ConsultationCharge;
                physicianDataToView.Specialty = specialtyRecord.First(rec => rec.SpecialtyID == p.SpecialtyID).SpecialtyName.ToString();
                physicianDataToView.Hospital = hospitalRecord.Single(rec => rec.HospitalID == p.HospitalID).HospitalName;
                dataToView.Add(physicianDataToView);
            }
            return dataToView;
        }
        public DataToView GetRecordForId(Guid id)
        {
            var fullRecord = GetFullRecord();
            var singleRecord = dataToView.SingleOrDefault(data => data.ID == id);
            return singleRecord;
        }
    }
}

