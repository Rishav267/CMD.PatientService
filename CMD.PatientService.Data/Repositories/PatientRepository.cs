using CMD.PatientService.Domain.Entities;
using CMD.PatientService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.PatientService.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientServiceDbContext db = new PatientServiceDbContext();

        #region Sync
        public ICollection<ActiveIssue> GetActiveIssuesById(int id)
        {
            return db.ActiveIssues.Where(a => a.PatientId == id).ToList();
        }

        public ICollection<Allergy> GetAllergiesById(int id)
        {
            return db.Allergies.Where(a => a.PatientId == id).ToList();
        }

        public ICollection<MedicalProblem> GetMedicalProblemsById(int id)
        {
            return db.MedicalProblems.Where(a => a.PatientId == id).ToList();
        }

        public Patient GetPatientById(int id)
        {
            return db.Patients.Find(id);
        }

        public ICollection<Symptom> GetSymptomsByPatId(int id)
        {
            return db.Symptoms.Where(a => a.PatientId == id).ToList();
        }

        ICollection<Patient> IPatientRepository.GetAllPatient()
        {
            return db.Patients.ToList();
        }
        #endregion

        #region Async
        public async Task<ICollection<ActiveIssue>> GetActiveIssuesByIdAsync(int id)
        {
            return await db.ActiveIssues.Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task<ICollection<Allergy>> GetAllergiesByIdAsync(int id)
        {
            return await db.Allergies.Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task<ICollection<MedicalProblem>> GetMedicalProblemsByIdAsync(int id)
        {
            return await db.MedicalProblems.Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await db.Patients.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Symptom>> GetSymptomsByPatIdAsync(int id)
        {
            return await db.Symptoms.Where(a => a.PatientId == id).ToListAsync();
        }
        public async Task<ICollection<Patient>> GetAllPatientAsync()
        {
            return await db.Patients.ToListAsync();
        }
        #endregion
    }
}
