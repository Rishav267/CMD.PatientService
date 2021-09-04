using CMD.PatientService.Domain.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        [TestMethod]
        public void TestMethod1()
        {
            int i1 = 0;
        }
    }
}
