using Hospital.BLL.Interfaces;
using Hospital.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.WEB.Util
{
    public class HospitalModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHospitalService>().To<HospitalService>();
            Bind<IDoctorService>().To<DoctorService>();
            Bind<IPatientService>().To<PatientService>();
            Bind<IPatientCardService>().To<PatientCardService>();
            Bind<IDoctorScheduleService>().To<DoctorScheduleService>();
            Bind<ITimetableService>().To<TimetableService>();
        }
    }
}