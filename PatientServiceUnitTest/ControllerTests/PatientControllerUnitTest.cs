using CMD.PatientService.Domain.APIModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientWebAPIServices.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientServiceUnitTest.ControllerTests
{
    [TestClass]
    public class PatientControllerUnitTest
    {
        [TestMethod]
        public void GetAllPatient_ShouldRetuenPatentList()
        {
            var patient = GetPatientDetails();
            var controller = new PatientController();
            var tempRes = controller.GetAllPatients() as ICollection<PatientAPIModel>;

            Assert.AreEqual(patient.Count, tempRes.Count);
        }
        [TestMethod]
        public void GetPatient_ShouldMatchPatientName()
        {
            var patient = GetPatientDetails() as List<PatientAPIModel>;
            var controller = new PatientController();
            var tempPatient = controller.GetPatientById(1) as PatientAPIModel;

            Assert.AreEqual(patient[1].Name, tempPatient.Name);
        }
        [TestMethod]
        public void GetPatient_ShouldMatchPatientLocation()
        {
            var patient = GetPatientDetails() as List<PatientAPIModel>;
            var controller = new PatientController();
            var tempPatient = controller.GetPatientById(1) as PatientAPIModel;

            Assert.AreEqual(patient[1].Location, tempPatient.Location);
        }
        [TestMethod]
        public void GetPatient_ShouldMatchPatientBllodGroup()
        {
            var patient = GetPatientDetails() as List<PatientAPIModel>;
            var controller = new PatientController();
            var tempPatient = controller.GetPatientById(1) as PatientAPIModel;

            Assert.AreEqual(patient[1].BloodGroup, tempPatient.BloodGroup);
        }

        [TestMethod]
        public async Task GetAllPatient_ShouldReturnAllPatient()
        {
            var patient = GetPatientDetails();
            var controller = new PatientController();
            var tempPatient = await controller.GetAllPatientsAsync() as ICollection<PatientAPIModel>;

            Assert.AreEqual(patient.Count, tempPatient.Count);
        }

        public async Task GetPatientAsync_ShouldMatchPatientName()
        {
            var patient = GetPatientDetails() as List<PatientAPIModel>;
            var controller = new PatientController();
            var tempPatient = await controller.GetPatientByIdAsync(1) as PatientAPIModel;

            Assert.AreEqual(patient[1].Name, tempPatient.Name);
        }


        private ICollection<PatientAPIModel> GetPatientDetails()
        {
            var patient = new List<PatientAPIModel>();
            patient.Add(new PatientAPIModel { Id = 1, Name = "Raj", Location = "India", Gender = "Male", BloodGroup = "AB-", Height = "158", DateOfBirth = Convert.ToDateTime("1989-08-08"), Image = "Image1", MobileNumber = "98987654", Age = "32" });
            patient.Add(new PatientAPIModel { Id = 2, Name = "John", Location = "Washington", Gender = "Male", BloodGroup = "A+", Height = "170", DateOfBirth = Convert.ToDateTime("1989-08-30"), Image = "Image2", MobileNumber = "41234567", Age = "30" });
            patient.Add(new PatientAPIModel { Id = 3, Name = "Kim", Location = "New York", Gender = "Male", BloodGroup = "B+", Height = "165", DateOfBirth = Convert.ToDateTime("1989-08-08"), Image = "Image3", MobileNumber = "98987654", Age = "31" });
            patient.Add(new PatientAPIModel { Id = 4, Name = "Natasha", Location = "Los Angeles'", Gender = "Female", BloodGroup = "A-", Height = "155", DateOfBirth = Convert.ToDateTime("1989-08-30"), Image = "Image4", MobileNumber = "41234567", Age = "33" });
            patient.Add(new PatientAPIModel { Id = 5, Name = "Rakesh", Location = "Cannada", Gender = "Male", BloodGroup = "AB+", Height = "160", DateOfBirth = Convert.ToDateTime("1989-08-08"), Image = "Image5", MobileNumber = "98987654", Age = "32" });
            patient.Add(new PatientAPIModel { Id = 6, Name = "Ramesh", Location = "India", Gender = "Male", BloodGroup = "O-", Height = "171", DateOfBirth = Convert.ToDateTime("1989-08-30"), Image = "Image6", MobileNumber = "41234567", Age = "32" });
            patient.Add(new PatientAPIModel { Id = 7, Name = "pratyusha", Location = "India", Gender = "Male", BloodGroup = "O-", Height = "171", DateOfBirth = Convert.ToDateTime("1989-08-30"), Image = "Image6", MobileNumber = "41234567", Age = "32" });
            return patient;
        }
        public IEnumerable<SymptomAPIModel> GetSymptomBy()
        {
            var symptom = new List<SymptomAPIModel>();
            symptom.Add(new SymptomAPIModel { Name = "Blood in urine", Description = "Hematuria" });
            symptom.Add(new SymptomAPIModel { Name = "Diabetes", Description = "250 Diabetes" });
            symptom.Add(new SymptomAPIModel { Name = "Weight loss", Description = "Body Mass Index is not proper" });
            symptom.Add(new SymptomAPIModel { Name = "Itching", Description = "On Face and Hand" });
            symptom.Add(new SymptomAPIModel { Name = "Indigestion", Description = "Food Poision" });
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
    }
}
