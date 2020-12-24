using Hospital.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.BLL.Interfaces
{
    public interface IDoctorScheduleService
    {
        IEnumerable<DoctorScheduleDTO> GetDoctorSchedulesById(int? id);
        IEnumerable<DoctorScheduleDTO> GetDoctorSchedules();
        void Dispose();
        //void EditDoctorSchedule(DoctorScheduleDTO doctorScheduleDto);
    }
}
