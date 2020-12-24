using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.WEB.Models
{
    public class PatientCardViewModel
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string TextInfo { get; set; }
        public DateTime DateOfRecord { get; set; }
        public IEnumerable<PatientViewModel> PatientViewModel { get; set; }
    }
}