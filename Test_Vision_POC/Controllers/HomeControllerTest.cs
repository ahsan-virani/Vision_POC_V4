using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Approach;
using MVC_Approach.Controllers;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

namespace Vision_POC_v4.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.AreEqual("Your contact page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void GetUsers()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.GetUsers() as ViewResult;

            // Assert
            // Check if the returned view is valid
            Assert.IsNotNull(result.ViewBag.Response);

        }

        [TestMethod]
        public void GetUsersWhenUserJsonIsNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act -- Mock controller so that it returns null / empty json
            ViewResult result = controller.GetUsers() as ViewResult;


            // Assert
            // Check if the returned view is valid
            Assert.IsNotNull(result.ViewBag.Response);

        }

        [TestMethod]
        public void GetUsersList()
        {
            //using (var httpClient = new HttpClient())
            //{
            //    var response = httpClient.GetAsync("http://localhost:54138/api/UserEF/").Result;

            //    // This works:
            //    return JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

            //    //// This may not work:
            //    //return response.Content.ReadAsAsync().Result;

            //    //// This may not work:
            //    //return response.Content.ReadAsOrDefaultAsync().Result;
            //}
        }
    }
}
