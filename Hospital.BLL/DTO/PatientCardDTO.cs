using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.BLL.DTO
{
    public class PatientCardDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string TextInfo { get; set; }
        public DateTime DateOfRecord { get; set; }
    }
}
