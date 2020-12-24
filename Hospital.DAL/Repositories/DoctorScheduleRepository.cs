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
    public class DoctorScheduleRepository : IRepository<DoctorSchedule>
    {
        private HospitalContext db;

        public DoctorScheduleRepository(HospitalContext context)
        {
            this.db = context;
        }

        public IEnumerable<DoctorSchedule> GetAll()
        {
            return db.DoctorSchedules;
        }

        public DoctorSchedule Get(int id)
        {
            return db.DoctorSchedules.Find(id);
        }

        public void Create(DoctorSchedule doctorSchedule)
        {
            db.DoctorSchedules.Add(doctorSchedule);
        }

        public void Update(DoctorSchedule doctorSchedule)
        {
            db.Entry(doctorSchedule).State = EntityState.Modified;
        }

        public IEnumerable<DoctorSchedule> Find(Func<DoctorSchedule, Boolean> predicate)
        {
            return db.DoctorSchedules.Include(o=>o.Doctor).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            DoctorSchedule doctorSchedule = db.DoctorSchedules.Find(id);
            if (doctorSchedule != null)
                db.DoctorSchedules.Remove(doctorSchedule);
        }
    }
}