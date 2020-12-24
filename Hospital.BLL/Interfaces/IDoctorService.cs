using Hospital.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.BLL.Interfaces
{
    public interface IDoctorService
    {
        DoctorDTO GetDoctor(int? id);
        IEnumerable<DoctorDTO> GetDoctors();
        void CreateDoctor(DoctorDTO doctorDto);
        void EditDoctor(DoctorDTO doctorDto);
        IEnumerable<DoctorDTO> GetDoctorsBySecondName(string secondName);
        void DeleteDoctor(int id);
        void Dispose();

    }
}
