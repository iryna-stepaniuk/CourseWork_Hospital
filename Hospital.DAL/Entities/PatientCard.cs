using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.DAL.Entities
{
    public class PatientCard
    {

        public int Id { get; set; }
        public int PatientId { get; set; }
        public string TextInfo { get; set; }
        public DateTime DateOfRecord { get; set; }
        public Patient Patient { get; set; }
    }
}

