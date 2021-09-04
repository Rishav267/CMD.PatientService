using AutoMapper;
using CMD.PatientService.Domain.APIModels;
using CMD.PatientService.Domain.Entities;
using CMD.PatientService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.PatientService.Domain.Managers
{
    public class Manager : IManager
    {
        private readonly IPatientRepository _patientRepository ;

        public Manager()
        {

        }

        public Manager(IPatientRepository repository)
        {
            _patientRepository = repository;
        }

        public IEnumerable<ActiveIssueAPIModel> GetActiveIssuesById(int id)
        {
            var activeissues = _patientRepository.GetActiveIssuesById(id);
            ICollection<ActiveIssueAPIModel> result = new List<ActiveIssueAPIModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ActiveIssue, ActiveIssueAPIModel>());
            var mapper = new Mapper(config);

            foreach (var item in activeissues)
            {
                result.Add(mapper.Map<ActiveIssueAPIModel>(item));
            }
            return result;
        }

        public IEnumerable<AllergyAPIModel> GetAllergiesById(int id)
        {
            var alleries = _patientRepository.GetAllergiesById(id);
            ICollection<AllergyAPIModel> result = new List<AllergyAPIModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Allergy, AllergyAPIModel>());
            var mapper = new Mapper(config);

            foreach (var item in alleries)
            {
                result.Add(mapper.Map<AllergyAPIModel>(item));
            }
            return result;
        }

        public IEnumerable<PatientAPIModel> GetAllPatient()
        {
            var patient = _patientRepository.GetAllPatient();
            ICollection<PatientAPIModel> result = new List<PatientAPIModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientAPIModel>());
            var mapper = new Mapper(config);

            foreach (var item in patient)
            {
                var newItem = mapper.Map<PatientAPIModel>(item);
                var year = DateTime.Now.Year - newItem.DateOfBirth.Year;
                newItem.Age = year.ToString();
                result.Add(newItem);
            }
            return result;
        }

        public IEnumerable<MedicalProblemAPIModel> GetMedicalProblemsById(int id)
        {
            var problem = _patientRepository.GetMedicalProblemsById(id);
            ICollection<MedicalProblemAPIModel> result = new List<MedicalProblemAPIModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MedicalProblem, MedicalProblemAPIModel>());
            var mapper = new Mapper(config);

            foreach (var item in problem)
            {
                result.Add(mapper.Map<MedicalProblemAPIModel>(item));
            }
            return result;
        }

        public PatientAPIModel GetPatientById(int id)
        {
            var patient = _patientRepository.GetPatientById(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientAPIModel>());
            var mapper = new Mapper(config);
            var newItem = mapper.Map<PatientAPIModel>(patient);
            var year = DateTime.Now.Year - newItem.DateOfBirth.Year;
            newItem.Age = year.ToString();
            return newItem;
        }

        public IEnumerable<SymptomAPIModel> GetSymptomsByPatId(int id)
        {
            var symptoms = _patientRepository.GetSymptomsByPatId(id);
            ICollection<SymptomAPIModel> result = new List<SymptomAPIModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Symptom, SymptomAPIModel>());
            var mapper = new Mapper(config);

            foreach (var item in symptoms)
            {
                result.Add(mapper.Map<SymptomAPIModel>(item));
            }
            return result;
        }
    }
}
