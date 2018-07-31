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
    public class PolicyApiControllerSeleniumTest {
        private static IWebDriver Driver;
        private static readonly String base_url = ConfigurationManager.AppSettings["baseUrl"]
                                        + ConfigurationManager.AppSettings["UrlGetAllPolicies"];
        

        [TestMethod]
        public void SeleniumTestUsingCSharp() {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(base_url);

            var responseElement = Driver.FindElements(By.TagName("PolicyDto"));

            var id = responseElement.First().FindElement(By.TagName("Id"));
            var amountInsured = responseElement.First().FindElement(By.TagName("AmountInsured"));
            var email = responseElement.First().FindElement(By.TagName("Email"));
            var inceptionDate = responseElement.First().FindElement(By.TagName("InceptionDate"));
            var installmentPayment = responseElement.First().FindElement(By.TagName("InstallmentPayment"));
            var clientId = responseElement.First().FindElement(By.TagName("ClientId"));

            Assert.IsNotNull(id);
            Assert.IsNotNull(amountInsured);
            Assert.IsNotNull(email);
            Assert.IsNotNull(inceptionDate);
            Assert.IsNotNull(installmentPayment);
            Assert.IsNotNull(clientId);
        }
    }
}