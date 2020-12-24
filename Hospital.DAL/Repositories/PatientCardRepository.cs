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
    public class PatientCardRepository : IRepository<PatientCard>
    {
        private HospitalContext db;

        public PatientCardRepository(HospitalContext context)
        {
            this.db = context;
        }

        public IEnumerable<PatientCard> GetAll()
        {
            return db.PatientCards;
        }

        public PatientCard Get(int id)
        {
            return db.PatientCards.Find(id);
        }

        public void Create(PatientCard patientCard)
        {
            db.PatientCards.Add(patientCard);
        }

        public void Update(PatientCard patientCard)
        {
            db.Entry(patientCard).State = EntityState.Modified;
        }

        public IEnumerable<PatientCard> Find(Func<PatientCard, Boolean> predicate)
        {
            return db.PatientCards.Include(o=>o.Patient).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            PatientCard patientCard = db.PatientCards.Find(id);
            if (patientCard != null)
                db.PatientCards.Remove(patientCard);
        }
    }
}
