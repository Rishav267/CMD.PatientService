using CMD.PatientService.Domain.APIModels;
using CMD.PatientService.Domain.Entities;
using CMD.PatientService.Domain.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UnitTestPatientService
{
    [TestClass]
    public class UnitTest1
    {
        Manager manager = null;

        [TestInitialize]
        public void Init()
        {
            manager = new Manager();
        }

        [TestCleanup]
        public void ClearIt()
        {
            manager = null;
        }

        private IEnumerable<PatientAPIModel> GetPatientDetails()
        {
            var patient = new List<PatientAPIModel>();
            patient.Add(new PatientAPIModel { Id = 1, Name = "Raj", Location = "India", Gender = "Male", BloodGroup = "AB-", Height = "158", DateOfBirth = Convert.ToDateTime("1989-08-08"), Image = "Image1", MobileNumber = "98987654",Age="32" });
            patient.Add(new PatientAPIModel { Id = 2, Name = "John", Location = "Washington", Gender = "Male", BloodGroup = "A+", Height = "170", DateOfBirth = Convert.ToDateTime("1989-08-30"), Image = "Image2", MobileNumber = "41234567",Age="30" });
            patient.Add(new PatientAPIModel { Id = 3, Name = "Kim", Location = "New York", Gender = "Male", BloodGroup = "B+", Height = "165", DateOfBirth = Convert.ToDateTime("1989-08-08"), Image = "Image3", MobileNumber = "98987654",Age="31" });
            patient.Add(new PatientAPIModel { Id = 4, Name = "Natasha", Location = "Los Angeles'", Gender = "Female", BloodGroup = "A-", Height = "155", DateOfBirth = Convert.ToDateTime("1989-08-30"), Image = "Image4", MobileNumber = "41234567",Age="33" });
            patient.Add(new PatientAPIModel { Id = 5, Name = "Rakesh", Location = "Cannada", Gender = "Male", BloodGroup = "AB+", Height = "160", DateOfBirth = Convert.ToDateTime("1989-08-08"), Image = "Image5", MobileNumber = "98987654",Age="32" });
            patient.Add(new PatientAPIModel { Id = 6, Name = "Ramesh", Location = "India", Gender = "Male", BloodGroup = "O-", Height = "171", DateOfBirth = Convert.ToDateTime("1989-08-30"), Image = "Image6", MobileNumber = "41234567",Age="32" });

            return patient;
        }

        public IEnumerable<SymptomAPIModel> GetSymptomBy()
        {
            var symptom = new List<SymptomAPIModel>();
            symptom.Add(new SymptomAPIModel {Name= "Blood in urine",Description= "Hematuria" });
            symptom.Add(new SymptomAPIModel {Name = "Diabetes" , Description= "250 Diabetes" });
            symptom.Add(new SymptomAPIModel {Name = "Weight loss", Description = "Body Mass Index is not proper" });
            symptom.Add(new SymptomAPIModel {Name = "Itching" , Description= "On Face and Hand" });
            symptom.Add(new SymptomAPIModel {Name = "Indigestion", Description = "Food Poision" });
            return symptom;
        }

        public IEnumerable<MedicalProblemAPIModel> GetMedicalProblem()
        {
            var medical = new List<MedicalProblemAPIModel>();
            medical.Add(new MedicalProblemAPIModel { Name = "Diabetes" });
            medical.Add(new MedicalProblemAPIModel { Name = "Cancer" });
            medical.Add(new MedicalProblemAPIModel { Name = "Obesity" });
            medical.Add(new MedicalProblemAPIModel { Name = "Asthama" });

            return medical;
        }

        public IEnumerable<AllergyAPIModel> GetAllergy()
        {
            var allergy = new List<AllergyAPIModel>();
            allergy.Add(new AllergyAPIModel { Name = "Food Allergy" });
            allergy.Add(new AllergyAPIModel { Name = "Drug Allergy" });
            allergy.Add(new AllergyAPIModel { Name = "Mosquitto Allergy" });
            allergy.Add(new AllergyAPIModel { Name = "Latex Allergy" });

            return allergy;
        }

        public IEnumerable<ActiveIssueAPIModel> GetActiveIssues()
        {
            var activeIssue = new List<ActiveIssueAPIModel>();
            activeIssue.Add(new ActiveIssueAPIModel { Name = "Headache" });
            activeIssue.Add(new ActiveIssueAPIModel { Name = "Back Pain" });
            activeIssue.Add(new ActiveIssueAPIModel { Name = "Fever" });
            activeIssue.Add(new ActiveIssueAPIModel { Name = "Head Injury" });

            return activeIssue;
        }

        [TestMethod]
        public void TestMethod1()
        {
            
        }
    }
}
