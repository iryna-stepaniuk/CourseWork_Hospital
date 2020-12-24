using Hospital.DAL.EF;
using Hospital.DAL.Entities;
using Hospital.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Hospital.DAL.Repositories
{
    public class PatientRepository : IRepository<Patient>
    {
        private HospitalContext db;

        public PatientRepository(HospitalContext context)
        {
            this.db = context;
        }

        public IEnumerable<Patient> GetAll()
        {
            return db.Patients;
        }

        public Patient Get(int id)
        {
            return db.Patients.Find(id);
        }

        public void Create(Patient patient)
        {
            db.Patients.Add(patient);
        
        }

        public void Update(Patient patient)
        {
            db.Entry(patient).State = EntityState.Modified;
        }

        public IEnumerable<Patient> Find(Func<Patient, Boolean> predicate)
        {
            return db.Patients.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Patient patient = db.Patients.Find(id);
            if (patient != null)
                db.Patients.Remove(patient);
        }
    }
}
