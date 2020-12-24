using Hospital.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.BLL.Interfaces
{
    public interface IPatientService
    {
        PatientDTO GetPatient(int? id);
        IEnumerable<PatientDTO> GetPatients();
        void CreatePatient(PatientDTO patientDto);
        void EditPatient(PatientDTO patientDto);
        IEnumerable<PatientDTO> GetPatientsBySecondName(string secondName);
        void DeletePatient(int id);
        void Dispose();
    }
}
