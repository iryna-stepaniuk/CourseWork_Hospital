using Hospital.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.BLL.Interfaces
{
    public interface ITimetableService
    {
        IEnumerable<TimetableDTO> GetTimetablesByDoctorId(int? id);
        IEnumerable<TimetableDTO> GetTimetablesByPatientId(int? id);
        IEnumerable<TimetableDTO> GetTimetables();
        void CreateTimetable(TimetableDTO timetableDto);
        void Dispose();
    }
}
