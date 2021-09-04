using CMD.PatientService.Domain.Managers;
using PatientWebAPIServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;

namespace PatientWebAPIServices.Controllers
{
    [RoutePrefix("api/patient")]
    public class PatientController : ApiController
    {        
        private readonly IManager manager = ManagerFactory.CreateManager();
        public IHttpActionResult GetAllPatients()
        {
            var result = manager.GetAllPatient();
            return Ok(result);
        }

        [Route("patient/{id}")]
        public IHttpActionResult GetPatientById(int id)
        {
            var patient = manager.GetPatientById(id);
            return Ok(patient);
        }
        [Route("symptom/{id}")]
        public IHttpActionResult GetSymptomById(int id)
        {
            var symptoms = manager.GetSymptomsByPatId(id);
            return Ok(symptoms);
        }
        [Route("activeissue/{id}")]
        public IHttpActionResult GetctiveIssues(int id)
        {
            var Activeissues = manager.GetActiveIssuesById(id);
            return Ok(Activeissues);
        }
        [Route("medicalproblem/{id}")]
        public IHttpActionResult GetMedicalProblemsById(int id)
        {
            var medicalProblems = manager.GetMedicalProblemsById(id);
            return Ok(medicalProblems);
        }
        [Route("allergy/{id}")]
        public IHttpActionResult GetAllergiesById(int id)
        {
            var allergies = manager.GetAllergiesById(id);
            return Ok(allergies);
        }

    }
}