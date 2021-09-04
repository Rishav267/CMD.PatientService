using CMD.PatientService.Data.Repositories;
using CMD.PatientService.Domain.Managers;
using CMD.PatientService.Domain.Repositories;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace PatientWebAPIServices.Models
{
    public class ManagerFactory
    {
            private static readonly IUnityContainer container;

            static ManagerFactory()
            {
                container = new UnityContainer();
                container.RegisterType<IManager, Manager>();
                container.RegisterType<IPatientRepository, PatientRepository>();
            // container.LoadConfiguration("PatientService");
        }

            public static IManager CreateManager()
            {
                return container.Resolve<IManager>();
            }
        }
}