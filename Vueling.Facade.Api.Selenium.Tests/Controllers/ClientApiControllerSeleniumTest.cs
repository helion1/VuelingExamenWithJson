using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Facade.ApiTests2.Controllers {

    [TestClass]
    public class ClientApiControllerSeleniumTest {
        private static IWebDriver Driver;
        private static String base_url = ConfigurationManager.AppSettings["baseUrl"]
                                        + ConfigurationManager.AppSettings["UrlGetAllClients"];

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
