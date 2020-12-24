using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.BLL.DTO
{
    public class DoctorScheduleDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int NumOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
