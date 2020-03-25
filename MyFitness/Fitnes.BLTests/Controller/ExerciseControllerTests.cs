using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitnes.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitnes.BL.Model;

namespace Fitnes.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTest
    {
        [TestMethod()]
         public void AddTest()
        {
            //Arrage 
            var userName = Guid.NewGuid().ToString();
            var activytyName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activiaty(activytyName, rnd.Next(50, 100));

            //Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            //Assert
            Assert.AreEqual(activytyName, exerciseController.Activiaties.First().Name);
        }
    }
}