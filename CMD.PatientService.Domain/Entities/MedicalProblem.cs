using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMD.PatientService.Domain.Entities
{
    public class MedicalProblem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get;set;}
        public virtual Patient Patient { get; set; }
    }
}
