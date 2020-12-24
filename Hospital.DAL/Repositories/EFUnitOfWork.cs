using System;
using System.Collections.Generic;
using System.Text;
using Hospital.DAL.EF;
using Hospital.DAL.Entities;
using Hospital.DAL.Interfaces;
using Hospital.DAL.Repositories;

namespace HospitalApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private HospitalContext db;
        private DoctorRepository doctorRepository;
        private PatientRepository patientRepository;
        private DoctorScheduleRepository doctorScheduleRepository;
        private PatientCardRepository patientCardRepository;
        private TimetableRepository timetableRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new HospitalContext(connectionString);
        }
        public IRepository<Doctor> Doctors
        {
            get
            {
                if (doctorRepository == null)
                    doctorRepository = new DoctorRepository(db);
                return doctorRepository;
            }
        }

        public IRepository<DoctorSchedule> DoctorSchedules
        {
            get
            {
                if (doctorScheduleRepository == null)
                    doctorScheduleRepository = new DoctorScheduleRepository(db);
                return doctorScheduleRepository;
            }
        }

        public IRepository<Patient> Patients
        {
            get
            {
                if (patientRepository == null)
                    patientRepository = new PatientRepository(db);
                return patientRepository;
            }
        }

        public IRepository<PatientCard> PatientCards
        {
            get
            {
                if (patientCardRepository == null)
                    patientCardRepository = new PatientCardRepository(db);
                return patientCardRepository;
            }
        }

        public IRepository<Timetable> Timetables
        {
            get
            {
                if (timetableRepository == null)
                    timetableRepository = new TimetableRepository(db);
                return timetableRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
