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
    public class TimetableRepository : IRepository<Timetable>
    {
        private HospitalContext db;

        public TimetableRepository(HospitalContext context)
        {
            this.db = context;
        }

        public IEnumerable<Timetable> GetAll()
        {
            return db.Timetables;
        }

        public Timetable Get(int id)
        {
            return db.Timetables.Find(id);
        }

        public void Create(Timetable timetable)
        {
            db.Timetables.Add(timetable);
        }

        public void Update(Timetable timetable)
        {
            db.Entry(timetable).State = EntityState.Modified;
        }

        public IEnumerable<Timetable> Find(Func<Timetable, Boolean> predicate)
        {
            return db.Timetables.Include(o => o.Patient).Include(o=>o.Doctor).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Timetable timetable = db.Timetables.Find(id);
            if (timetable != null)
                db.Timetables.Remove(timetable);
        }
    }
}
