using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;

using TrainingAPI.Models;
using TrainingAPI.Controllers;
using System.Web.Http;
using System.Collections.Generic;

namespace TrainingTests.Controllers
{
    ///<summary>
    /// This class designed for Unit testing.
    /// Both positive and negative test cases can be added.
    /// This automated test case execution help to identify issues before deployment. 
    /// </summary>
    [TestClass]
    public class TrainingControllerTest
    {
        [TestMethod]
        public void GetAllTraining()
        {
            var data = new TestTrainingAppContext();

            data.Trainings.Add(new Training { TrainingName = "Test Training1", StartDate = DateTime.Today.AddDays(3), EndDate = DateTime.Today.AddDays(7) });
            data.Trainings.Add(new Training { TrainingName = "Test Training2", StartDate = DateTime.Today.AddDays(1), EndDate = DateTime.Today.AddDays(3) });
            data.Trainings.Add(new Training { TrainingName = "Test Training3", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(1) });

            var controller = new TrainingsController(data);
            var result = controller.GetTrainings() as TestTrainingDBSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3,result.Local.Count);
        }

        [TestMethod]
        public void PostTrainingData()
        {
           
            var controller = new TrainingsController(new TestTrainingAppContext());
            var data = GetDemoTraining();
            

            IHttpActionResult result = controller.PostTraining(data);
            var okresult = result as OkNegotiatedContentResult<List<string>>;

            Assert.IsNotNull(result);
            Assert.AreEqual("result:Success", okresult.Content[0]);
        }

        //Invalid data Test case

        [TestMethod]
        public void PostTrainingInvalidData()
        {

            var controller = new TrainingsController(new TestTrainingAppContext());
            var data = GetDemoTraining();
            data.Id = 0;

            IHttpActionResult result = controller.PostTraining(data);
            Assert.IsInstanceOfType(result,typeof(BadRequestResult));
        }

        Training GetDemoTraining()
        {
            return new Training() { Id = 3, TrainingName = "Test Training", StartDate=DateTime.Today, EndDate = DateTime.Today.AddDays(2) };
        }
    }
}
