using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Linq;
using System.Configuration;
using System.Web;
using Newtonsoft.Json;
using Vueling.Domain.Entities;
using System.Net;

namespace Vueling.Facade.ApiTests2 {

    [TestClass]
    public class SeleniumCSharp {
        private static IWebDriver Driver;
        private static String base_url = ConfigurationManager.AppSettings["baseUrl"]
                                       + ConfigurationManager.AppSettings["UrlGetAllClients"];

        //private static String base_url = "http://localhost:57896/api/ClientApi";

        [AssemblyInitialize]
        public static void AssemblyInit(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context) {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(base_url);
        }

        [AssemblyCleanup]
        public static void AssemblyTearDown() {
            Driver.Close();
            Driver.Quit();
        }

        [TestMethod]
        public void SeleniumTestUsingCSharp() {
            var responseElement = Driver.FindElements(By.TagName("ClientDto"));

            var id = responseElement.First().FindElement(By.TagName("Id"));
            var name = responseElement.First().FindElement(By.TagName("Name"));
            var email = responseElement.First().FindElement(By.TagName("Email"));
            var role = responseElement.First().FindElement(By.TagName("Role"));

            Assert.IsNotNull(id);
            Assert.IsNotNull(name);
            Assert.IsNotNull(email);
            Assert.IsNotNull(role);
        }
    }
}
