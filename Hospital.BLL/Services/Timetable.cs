using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using Hospital.DAL.Entities;
using Hospital.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.BLL.Services
{
    public class TimetableService:ITimetableService
    {
        IUnitOfWork Database { get; set; }

        public TimetableService(IUnitOfWork uow)
        {
            Database = uow;
        }


        public IEnumerable<TimetableDTO> GetTimetables()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Timetable, TimetableDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Timetable>, List<TimetableDTO>>(Database.Timetables.GetAll());
        }

        public IEnumerable<TimetableDTO> GetTimetablesByDoctorId(int? doctorid)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Timetable, TimetableDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Timetable>, List<TimetableDTO>>(Database.Timetables.Find(p => p.DoctorId == doctorid));
        }
        public IEnumerable<TimetableDTO> GetTimetablesByPatientId(int? patientid)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Timetable, TimetableDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Timetable>, List<TimetableDTO>>(Database.Timetables.Find(p => p.PatientId == patientid));
        }

        public void CreateTimetable(TimetableDTO timetableDto)
        {
            Timetable timetable = new Timetable
            {
                PatientId = timetableDto.PatientId,
                DoctorId = timetableDto.DoctorId,
                StartTime = timetableDto.StartTime,
                EndTime = timetableDto.EndTime,
            };
            Database.Timetables.Create(timetable);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
