﻿using CMD.PatientService.Domain.APIModels;
using CMD.PatientService.Domain.Managers;
using PatientWebAPIServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Unity;

namespace PatientWebAPIServices.Controllers
{
    [RoutePrefix("api")]
    public class PatientController : ApiController
    {        
        private readonly IManager manager = ManagerFactory.CreateManager();

        #region sync
        [Route("patient")]
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
        #endregion


        #region Async
        [Route("async/patient")]
        public async Task<IHttpActionResult> GetAllPatientsAsync()
        {
            return Ok(await manager.GetAllPatientAsync());
        }

        [Route("async/patient/{id}")]
        public async Task<IHttpActionResult> GetPatientByIdAsync(int id)
        {
            return Ok(await manager.GetPatientByIdAsync(id));
        }
        [Route("async/symptom/{id}")]
        public async Task<IHttpActionResult> GetSymptomByIdAsync(int id)
        {
            
            return Ok(await manager.GetSymptomsByPatIdAsync(id));
        }
        [Route("async/activeissue/{id}")]
        public async Task<IHttpActionResult> GetctiveIssuesAsync(int id)
        {
            return Ok(await manager.GetActiveIssuesByIdAsync(id));
        }
        [Route("async/medicalproblem/{id}")]
        public async Task<IHttpActionResult> GetMedicalProblemsByIdAsync(int id)
        {
            return Ok(await manager.GetMedicalProblemsByIdAsync(id));
        }
        [Route("async/allergy/{id}")]
        public async Task<IHttpActionResult> GetAllergiesByIdAsync(int id)
        {
            return Ok(await manager.GetAllergiesByIdAsync(id));
        }
        #endregion
    }
}