using Hospital.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Doctor> Doctors { get; }
        IRepository<Patient> Patients { get; }
        IRepository<DoctorSchedule> DoctorSchedules { get; }
        IRepository<PatientCard> PatientCards { get; }
        IRepository<Timetable> Timetables { get; }
        void Save();
    }
}
