using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public IWebDriver Driver;
        public WebDriverWait Wait;

        [TestInitialize]
        public void SetupTest()
        {
            this.Driver = new InternetExplorerDriver(@"G:\IEDriverServer_x64_2.53.1");
            //this.Driver = new FirefoxDriver();
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));
            this.Driver.Navigate().GoToUrl("https://www.expedia.com/Flights");
        }

        [TestCleanup]
        public void TeardownTest()
        {
            //this.Driver.Quit();
        }

        [TestMethod]
        public void FillFlightsForm()
        {
            FlightsPage flightsPage = new FlightsPage(this.Driver);
            flightsPage.autoField(false, "Kiev", "Lviv", "01/02/2017", "01/02/2017", "2", "0", "Business");
        }

    }
}
