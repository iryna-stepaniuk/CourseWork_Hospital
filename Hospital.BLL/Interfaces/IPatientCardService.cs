using Hospital.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.BLL.Interfaces
{
    public interface IPatientCardService
    {
        IEnumerable<PatientCardDTO> GetPatientCardsById(int? id);
        IEnumerable<PatientCardDTO> GetPatientCards();
        void CreatePatientCard(PatientCardDTO patientCardDto);
        void Dispose();
    }
}
