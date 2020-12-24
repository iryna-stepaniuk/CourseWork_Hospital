using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.WEB.Models
{
    public class DoctorScheduleViewModel
    {
        public class DoctorScheduleViewModule
        {
            public int Id { get; set; }
            public int DoctorId { get; set; }
            public int NumOfWeek { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }
    }
}