using CMD.PatientService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.PatientService.Domain.Repositories
{
    public interface IPatientRepository
    {
        ICollection<Patient> GetAllPatient();
        Patient GetPatientById(int id);

        ICollection<Symptom> GetSymptomsByPatId(int id);

        ICollection<Allergy> GetAllergiesById(int id);

        ICollection<MedicalProblem> GetMedicalProblemsById(int id);

        ICollection<ActiveIssue> GetActiveIssuesById(int id);
    }
}
