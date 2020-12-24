using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.WEB.Models
{
    public class TimetableViewModel
    {

            public int DoctorId { get; set; }
            public int PatientId { get; set; }
            public DateTime Date { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }

    }
}