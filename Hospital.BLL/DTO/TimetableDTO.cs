using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.BLL.DTO
{
    public class TimetableDTO
    {
        public int DoctorId { get; set; }

        public int PatientId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
