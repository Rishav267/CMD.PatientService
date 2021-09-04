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
        IEnumerable<PatientAPIModel> GetAllPatient();
        PatientAPIModel GetPatientById(int id);

        IEnumerable<SymptomAPIModel> GetSymptomsByPatId(int id);

        IEnumerable<AllergyAPIModel> GetAllergiesById(int id);

        IEnumerable<MedicalProblemAPIModel> GetMedicalProblemsById(int id);

        IEnumerable<ActiveIssueAPIModel> GetActiveIssuesById(int id);
    }
}
