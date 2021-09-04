using CMD.PatientService.Domain.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace CMD.PatientService.Data
{
    public class PatientServiceDbContext : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CMD.PatientService.Data.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public PatientServiceDbContext()
            : base("name=DefaultConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public IDbSet<ActiveIssue> ActiveIssues { get; set; }
        public IDbSet<Allergy> Allergies { get; set; }
        public IDbSet<MedicalProblem> MedicalProblems { get; set; }
        public IDbSet<Patient> Patients { get; set; }
        public IDbSet<Symptom> Symptoms { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}