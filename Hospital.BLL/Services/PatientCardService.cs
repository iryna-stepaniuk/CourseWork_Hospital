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
    public class PatientCardService:IPatientCardService
    {
        IUnitOfWork Database { get; set; }

        public PatientCardService(IUnitOfWork uow)
        {
            Database = uow;
        }


        public IEnumerable<PatientCardDTO> GetPatientCards()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PatientCard, PatientCardDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<PatientCard>, List<PatientCardDTO>>(Database.PatientCards.GetAll());
        }

        public IEnumerable<PatientCardDTO> GetPatientCardsById(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PatientCard, PatientCardDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<PatientCard>, List<PatientCardDTO>>(Database.PatientCards.Find(p => p.PatientId == id));
        }

        public void CreatePatientCard(PatientCardDTO patientCardDto)
        {
            Patient patient = Database.Patients.Get(patientCardDto.PatientId);

            // валидация
            if (patient == null)
                throw new ValidationException("Patient не найден", "");
            // применяем скидку
            PatientCard patientCard = new PatientCard
            {
                DateOfRecord = DateTime.Now,
                TextInfo = patientCardDto.TextInfo,
                PatientId = patient.Id,
            };
            Database.PatientCards.Create(patientCard);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
