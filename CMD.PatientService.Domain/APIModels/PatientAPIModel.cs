using CMD.PatientService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.PatientService.Domain.APIModels
{
    public class PatientAPIModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Height { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
        public string MobileNumber { get; set; }

        public string Age { get; set; }

    }
}
