using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.PatientService.Domain.Entities
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        //[StringLength(160, MinimumLength = 3)]
        //[MinLength(3)]
        //[Required]
        public string Name { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Height { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
        public string MobileNumber { get; set; }  // string

    }
}

