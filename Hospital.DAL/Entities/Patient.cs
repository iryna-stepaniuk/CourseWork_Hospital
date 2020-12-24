using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }


        public ICollection<PatientCard> PatientCards { get; set; }
        public Patient()
        {
            PatientCards = new List<PatientCard>();
        }
    }
}
