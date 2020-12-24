using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Specialization { get; set; }

        public ICollection<DoctorSchedule> Schedule { get; set; }
        public Doctor()
        {
            Schedule = new List<DoctorSchedule>();
        }
    }
}
