using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.DAL.Entities
{
    public class Timetable
    {
        [Key, ForeignKey("Doctor")]
        [Column("DoctorId", Order = 0)]
        public int DoctorId { get; set; }

        [Key, ForeignKey("Patient")]
        [Column(Order = 1)]
        public int PatientId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
