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
        #region Sync
        ICollection<Patient> GetAllPatient();
        Patient GetPatientById(int id);

        ICollection<Symptom> GetSymptomsByPatId(int id);

        ICollection<Allergy> GetAllergiesById(int id);

        ICollection<MedicalProblem> GetMedicalProblemsById(int id);

        ICollection<ActiveIssue> GetActiveIssuesById(int id);
        #endregion

        #region Async
        Task<ICollection<Patient>> GetAllPatientAsync();
        Task<Patient> GetPatientByIdAsync(int id);

        Task<ICollection<Symptom>> GetSymptomsByPatIdAsync(int id);

        Task<ICollection<Allergy>> GetAllergiesByIdAsync(int id);

        Task<ICollection<MedicalProblem>> GetMedicalProblemsByIdAsync(int id);

        Task<ICollection<ActiveIssue>> GetActiveIssuesByIdAsync(int id);
        #endregion
    }
}
