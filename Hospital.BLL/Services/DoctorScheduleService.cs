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
    public class DoctorScheduleService: IDoctorScheduleService
    {
        IUnitOfWork Database { get; set; }

        public DoctorScheduleService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<DoctorScheduleDTO> GetDoctorSchedules()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DoctorSchedule, DoctorScheduleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<DoctorSchedule>, List<DoctorScheduleDTO>>(Database.DoctorSchedules.GetAll());
        }

        public IEnumerable<DoctorScheduleDTO> GetDoctorSchedulesById(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DoctorSchedule, DoctorScheduleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<DoctorSchedule>, List<DoctorScheduleDTO>>(Database.DoctorSchedules.Find(p => p.Id == id));
        }


        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
