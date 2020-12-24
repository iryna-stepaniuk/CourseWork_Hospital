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
    public class DoctorService: IDoctorService
    {
        IUnitOfWork Database { get; set; }

        public DoctorService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<DoctorDTO> GetDoctors()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Doctor>, List<DoctorDTO>>(Database.Doctors.GetAll());
        }

        public DoctorDTO GetDoctor(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id doctor", "");
            var doctor = Database.Doctors.Get(id.Value);
            if (doctor == null)
                throw new ValidationException("Doctor не найден", "");

            return new DoctorDTO { Id = doctor.Id, FirstName = doctor.FirstName, SecondName = doctor.SecondName, Specialization = doctor.Specialization };
        }

        public void CreateDoctor(DoctorDTO doctorDto)
        {
            Doctor doctor = new Doctor
            {
                FirstName = doctorDto.FirstName,
                SecondName = doctorDto.SecondName,
                Specialization = doctorDto.Specialization
            };
            Database.Doctors.Create(doctor);
            Database.Save();
        }
        public void EditDoctor(DoctorDTO doctorDTO)
        {
            var doctor = Database.Doctors.Get(doctorDTO.Id);
            Database.Doctors.Get(doctorDTO.Id).FirstName = doctorDTO.FirstName;
            Database.Doctors.Get(doctorDTO.Id).SecondName = doctorDTO.SecondName;
            Database.Doctors.Get(doctorDTO.Id).Specialization = doctorDTO.Specialization;
            //Database.Doctors.Update(doctor);
            Database.Save();
        }

        public void DeleteDoctor(int id)
        {
            Database.Doctors.Delete(id);
            Database.Save();
        }

        public IEnumerable<DoctorDTO> GetDoctorsBySecondName(string secondName)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Doctor>, List<DoctorDTO>>(Database.Doctors.Find(p => p.SecondName == secondName));
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
