using CMD.PatientService.Domain.Entities;
using CMD.PatientService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.PatientService.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientServiceDbContext db = new PatientServiceDbContext();
        public ICollection<ActiveIssue> GetActiveIssuesById(int id)
        {
            return db.ActiveIssues.Where(a => a.PatientId == id).ToList();
        }

        public ICollection<Allergy> GetAllergiesById(int id)
        {
            return db.Allergies.Where(a => a.PatientId == id).ToList();
        }

        //public List<Patient> GetAllPatient()
        //{
        //    return db.Patients.ToList();
        //}

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
    }
}
