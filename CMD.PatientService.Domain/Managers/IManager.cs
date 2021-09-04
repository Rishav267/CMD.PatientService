using CMD.PatientService.Domain.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.PatientService.Domain.Managers
{
    public interface IManager
    {
        #region Sync
        IEnumerable<PatientAPIModel> GetAllPatient();
        PatientAPIModel GetPatientById(int id);

        IEnumerable<SymptomAPIModel> GetSymptomsByPatId(int id);

        IEnumerable<AllergyAPIModel> GetAllergiesById(int id);

        IEnumerable<MedicalProblemAPIModel> GetMedicalProblemsById(int id);

        IEnumerable<ActiveIssueAPIModel> GetActiveIssuesById(int id);
        #endregion

        #region Async
        Task<IEnumerable<PatientAPIModel>> GetAllPatientAsync();
        Task<PatientAPIModel> GetPatientByIdAsync(int id);

        Task<IEnumerable<SymptomAPIModel>> GetSymptomsByPatIdAsync(int id);

        Task<IEnumerable<AllergyAPIModel>> GetAllergiesByIdAsync(int id);

        Task<IEnumerable<MedicalProblemAPIModel>> GetMedicalProblemsByIdAsync(int id);

        Task<IEnumerable<ActiveIssueAPIModel>> GetActiveIssuesByIdAsync(int id);
        #endregion
    }
}
