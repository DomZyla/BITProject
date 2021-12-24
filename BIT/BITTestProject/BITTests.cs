using FastDrivers.ViewModel;
using FastDrivers.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITTestProject
{
    [TestClass]
    public class BITTests
    {

        /// <summary>
        /// Tests that a skill exists and has been counted 
        /// </summary>
        [TestMethod]
        public void TestSkillCollectionMock()
        {
            ObservableCollection<Skill> mockSkills = new ObservableCollection<Skill>();

            mockSkills.Add(new Skill
            {
                SkillName = "ComputerCleaner",
                Description = "Cleans Harddrive/storage devices"
            });

            Mock<SkillManagementViewModel> mockSkillVM = new Mock<SkillManagementViewModel>();

            mockSkillVM.Setup(m => m.GetSkills()).Returns(mockSkills);

            int count = mockSkillVM.Object.Skills.Count;

            Assert.AreEqual(1, count);
        }
        
        /// <summary>
        /// Tests that contractors are coming through and counted as more than 1
        /// </summary>
        [TestMethod]
        public void TestContractorCollection()
        {
            ContractorManagementViewModel contractorViewModel = new ContractorManagementViewModel();

            int count = contractorViewModel.Contractors.Count;

            Assert.IsTrue(count > 1);
        }

        /// <summary>
        /// Tests Updating a job request KM travelled
        /// </summary>
        [TestMethod]
        public void UpdateJobRequestTest()
        {

            JobManagementViewModel jobViewModel = new JobManagementViewModel();

            int km = 24;
            int jobRequestId = 1;


            int actual = jobViewModel.UpdateMethodTest(km,jobRequestId);

            const int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the collection for coordinators
        /// </summary>
        [TestMethod]
        public void TestCoordinatorCollection()
        {
            CoordinatorManagementViewModel coordinatorViewModel = new CoordinatorManagementViewModel();

            int count = coordinatorViewModel.Coordinators.Count;

            Assert.IsTrue(count > 1);
        }
    }
}
