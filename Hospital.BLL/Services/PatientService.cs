using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Infrastructure;
using Hospital.BLL.Interfaces;
using Hospital.DAL.Entities;
using Hospital.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.BLL.Services
{
    public class PatientService:IPatientService
    {
        IUnitOfWork Database { get; set; }

        public PatientService(IUnitOfWork uow)
        {
            Database = uow;
        }



        public IEnumerable<PatientDTO> GetPatients()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Patient>, List<PatientDTO>>(Database.Patients.GetAll());
        }

        public PatientDTO GetPatient(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id patient", "");
            var patient = Database.Patients.Get(id.Value);
            if (patient == null)
                throw new ValidationException("Patient не найден", "");

            return new PatientDTO { Id = patient.Id, FirstName = patient.FirstName, SecondName = patient.SecondName };
        }
        //public void EditPatient(PatientDTO patientDTO)
        //{
        //    var patient = Database.Patients.Get(patientDTO.Id);
        //    Database.Patients.Update(patient);
        //    Database.Save();
        //}

        public void EditPatient(PatientDTO patientDTO)
        {
            var patient = Database.Patients.Get(patientDTO.Id);
            Database.Patients.Get(patientDTO.Id).FirstName = patientDTO.FirstName;
            Database.Patients.Get(patientDTO.Id).SecondName = patientDTO.SecondName;
            //Database.Doctors.Update(doctor);
            Database.Save();
        }

        public void CreatePatient(PatientDTO patientDto)
        {
            Patient patient = new Patient
            {
                FirstName = patientDto.FirstName,
                SecondName = patientDto.SecondName
            };
            Database.Patients.Create(patient);
            Database.Save();
        }

        public void DeletePatient(int id)
        {
            Database.Patients.Delete(id);
            Database.Save();
        }

        public IEnumerable<PatientDTO> GetPatientsBySecondName(string secondName)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Patient>, List<PatientDTO>>(Database.Patients.Find(p => p.SecondName == secondName));
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
