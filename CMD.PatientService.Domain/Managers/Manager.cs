using AutoMapper;
using CMD.PatientService.Domain.APIModels;
using CMD.PatientService.Domain.Entities;
using CMD.PatientService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CMD.PatientService.Domain.Managers
{
    public class Manager : IManager
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ObjectCache _cache = new MemoryCache("PatientCache");

        public Manager()
        {

        }

        public Manager(IPatientRepository repository)
        {
            _patientRepository = repository;
        }

        #region Sync
        public IEnumerable<ActiveIssueAPIModel> GetActiveIssuesById(int id)
        {
            var cached_activeissues = _cache.Get(String.Concat("ActiveIssue-", id));
            if (cached_activeissues != null)
                return (IEnumerable<ActiveIssueAPIModel>)cached_activeissues;

            var activeissues = _patientRepository.GetActiveIssuesById(id);
            ICollection<ActiveIssueAPIModel> result = new List<ActiveIssueAPIModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ActiveIssue, ActiveIssueAPIModel>());
            var mapper = new Mapper(config);

            foreach (var item in activeissues)
            {
                result.Add(mapper.Map<ActiveIssueAPIModel>(item));
            }
            _cache.Set(String.Concat("ActiveIssue-", id), result, DateTimeOffset.Now.AddMinutes(10));
            return result;
        }

       
        public IEnumerable<AllergyAPIModel> GetAllergiesById(int id)
        {
            var cached_alleries = _cache.Get(String.Concat("Allergy-", id));
            if (cached_alleries != null)
                return (IEnumerable<AllergyAPIModel>)cached_alleries;
            var alleries = _patientRepository.GetAllergiesById(id);
            ICollection<AllergyAPIModel> result = new List<AllergyAPIModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Allergy, AllergyAPIModel>());
            var mapper = new Mapper(config);

            foreach (var item in alleries)
            {
                result.Add(mapper.Map<AllergyAPIModel>(item));
            }
            _cache.Set(String.Concat("Allergy-", id), result, DateTimeOffset.Now.AddMinutes(10));
            return result;
        }



        public IEnumerable<PatientAPIModel> GetAllPatient()
        {
            var cached_patients = _cache.Get("Patients");
            if (cached_patients != null)
                return (IEnumerable<PatientAPIModel>)cached_patients;
            var patients = _patientRepository.GetAllPatient();
            ICollection<PatientAPIModel> result = new List<PatientAPIModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientAPIModel>());
            var mapper = new Mapper(config);

            foreach (var item in patients)
            {
                var newItem = mapper.Map<PatientAPIModel>(item);
                var year = DateTime.Now.Year - newItem.DateOfBirth.Year;
                newItem.Age = year.ToString();
                result.Add(newItem);
            }
            _cache.Set("Patients", result, DateTimeOffset.Now.AddMinutes(10));
            return result;
        }



        public IEnumerable<MedicalProblemAPIModel> GetMedicalProblemsById(int id)
        {
            var cached_problems = _cache.Get(String.Concat("Problem-", id));
            if (cached_problems != null)
                return (IEnumerable<MedicalProblemAPIModel>)cached_problems;
            var problem = _patientRepository.GetMedicalProblemsById(id);
            ICollection<MedicalProblemAPIModel> result = new List<MedicalProblemAPIModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MedicalProblem, MedicalProblemAPIModel>());
            var mapper = new Mapper(config);

            foreach (var item in problem)
            {
                result.Add(mapper.Map<MedicalProblemAPIModel>(item));
            }
            _cache.Set(String.Concat("Problem-", id), result, DateTimeOffset.Now.AddMinutes(10));
            return result;
        }



        public PatientAPIModel GetPatientById(int id)
        {
            var cached_patient = (PatientAPIModel)_cache.Get(String.Concat("Patient-", id));
            if ( cached_patient!= null)
            {
                return cached_patient;
            }
            var patient = _patientRepository.GetPatientById(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientAPIModel>());
            var mapper = new Mapper(config);
            var newItem = mapper.Map<PatientAPIModel>(patient);
            var year = DateTime.Now.Year - newItem.DateOfBirth.Year;
            newItem.Age = year.ToString();
            _cache.Set(String.Concat("Patient-", id), newItem, DateTimeOffset.Now.AddMinutes(10));
            return newItem;
        }



        public IEnumerable<SymptomAPIModel> GetSymptomsByPatId(int id)
        {
            var cached_symptoms = _cache.Get(String.Concat("Symptom-", id));
            if (cached_symptoms != null)
                return (IEnumerable<SymptomAPIModel>)cached_symptoms;
            var symptoms = _patientRepository.GetSymptomsByPatId(id);
            ICollection<SymptomAPIModel> result = new List<SymptomAPIModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Symptom, SymptomAPIModel>());
            var mapper = new Mapper(config);

            foreach (var item in symptoms)
            {
                result.Add(mapper.Map<SymptomAPIModel>(item));
            }
            _cache.Set(String.Concat("Symptom-", id), result, DateTimeOffset.Now.AddMinutes(10));
            return result;
        }

        #endregion

        #region Async
        public async Task<IEnumerable<ActiveIssueAPIModel>> GetActiveIssuesByIdAsync(int id)
        {
            var activeissues = await _patientRepository.GetActiveIssuesByIdAsync(id);
            ICollection<ActiveIssueAPIModel> result = new List<ActiveIssueAPIModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ActiveIssue, ActiveIssueAPIModel>());
            var mapper = new Mapper(config);

            foreach (var item in activeissues)
            {
                result.Add(mapper.Map<ActiveIssueAPIModel>(item));
            }
            return result;
        }

        public async Task<IEnumerable<AllergyAPIModel>> GetAllergiesByIdAsync(int id)
        {
            var alleries = await _patientRepository.GetAllergiesByIdAsync(id);
            ICollection<AllergyAPIModel> result = new List<AllergyAPIModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Allergy, AllergyAPIModel>());
            var mapper = new Mapper(config);

            foreach (var item in alleries)
            {
                result.Add(mapper.Map<AllergyAPIModel>(item));
            }
            return result;
        }

        public async Task<IEnumerable<PatientAPIModel>> GetAllPatientAsync()
        {
            var patient = await _patientRepository.GetAllPatientAsync();
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

        public async Task<IEnumerable<MedicalProblemAPIModel>> GetMedicalProblemsByIdAsync(int id)
        {
            var problem = await _patientRepository.GetMedicalProblemsByIdAsync(id);
            ICollection<MedicalProblemAPIModel> result = new List<MedicalProblemAPIModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MedicalProblem, MedicalProblemAPIModel>());
            var mapper = new Mapper(config);

            foreach (var item in problem)
            {
                result.Add(mapper.Map<MedicalProblemAPIModel>(item));
            }
            return result;
        }

        public async Task<PatientAPIModel> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientAPIModel>());
            var mapper = new Mapper(config);
            var newItem = mapper.Map<PatientAPIModel>(patient);
            var year = DateTime.Now.Year - newItem.DateOfBirth.Year;
            newItem.Age = year.ToString();
            return newItem;
        }

        public async Task<IEnumerable<SymptomAPIModel>> GetSymptomsByPatIdAsync(int id)
        {
            var symptoms = await _patientRepository.GetSymptomsByPatIdAsync(id);
            ICollection<SymptomAPIModel> result = new List<SymptomAPIModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Symptom, SymptomAPIModel>());
            var mapper = new Mapper(config);

            foreach (var item in symptoms)
            {
                result.Add(mapper.Map<SymptomAPIModel>(item));
            }
            return result;
        }
        #endregion
    }
}
