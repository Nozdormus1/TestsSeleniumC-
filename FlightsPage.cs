using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace UnitTestProject1
{
    public class FlightsPage
    {
        private readonly IWebDriver driver;

        public FlightsPage(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "flight-type-one-way")]
        public IWebElement oneWay { get; set; }

        [FindsBy(How = How.Id, Using = "flight-type-roundtrip")]
        public IWebElement roundTrip { get; set; }

        [FindsBy(How = How.Id, Using = "flight-origin")]
        public IWebElement flightOrigin { get; set; }

        [FindsBy(How = How.Id, Using = "flight-destination")]
        public IWebElement flightDestination { get; set; }

        [FindsBy(How = How.Id, Using = "flight-departing")]
        public IWebElement departingDate { get; set; }

        [FindsBy(How = How.Id, Using = "flight-returning")]
        public IWebElement returningDate { get; set; }

        [FindsBy(How = How.Id, Using = "flight-adults")]
        public IWebElement adultsCount { get; set; }

        [FindsBy(How = How.Id, Using = "flight-children")]
        public IWebElement childrenCount { get; set; }

        [FindsBy(How = How.LinkText, Using = "Advanced options")]
        public IWebElement advancedOptions { get; set; }

        [FindsBy(How = How.Id, Using = "search-button")]
        public IWebElement searchButton { get; set; }

        //Set flight mode
        public void setFlightMode(bool setOneWayDirection)
        {
            if (setOneWayDirection)
            {
                this.oneWay.Click();
            }
            else
            {
                this.roundTrip.Click();
            }
        }

        //Set flight origin
        public void setFlightOrigin(string strFlightOrigin)
        {
            this.flightOrigin.Clear();
            this.flightOrigin.SendKeys(strFlightOrigin);
        }

        //Set flight destination
        public void setFlightDestination(string strFlightDestination)
        {
            this.flightDestination.Clear();
            this.flightDestination.SendKeys(strFlightDestination);
        }

        //Set departing date
        public void setDepartingDate(string strDepartingDate)
        {
            this.departingDate.Clear();
            this.departingDate.SendKeys(strDepartingDate);
        }

        //Set returning date
        public void setReturningDate(string strReturningDate)
        {
            this.returningDate.Clear();
            this.returningDate.SendKeys(strReturningDate);
        }

        //Set number of adults
        public void setAdultsCount(string strAdultsCount)
        {
            SelectElement selector = new SelectElement(adultsCount);
            selector.SelectByText(strAdultsCount);
        }

        //Set number of children
        public void setChildrenCount(string strChildrenCount)
        {
            SelectElement selector = new SelectElement(childrenCount);
            selector.SelectByText(strChildrenCount);
        }

        //Click on advanced options
        public void clickAdvancedOptions()
        {
            this.advancedOptions.Click();
        }

        //Set flight class
        public void setFlightClass(string strFlightClass)
        {
            SelectElement selector = new SelectElement(driver.FindElement(By.Id("flight-advanced-preferred-class")));
            selector.SelectByText(strFlightClass);
        }

        //Click on search
        public void clickSearchButton()
        {
            this.searchButton.Click();
        }


        public void autoField(bool setOneWayDirection, string strFlightOrigin, string strFlightDestination, string strDepartingDate, string strReturningDate, string strAdultsCount, string strChildrenCount, string strFlightClass)
        {
            //set flight mode
            this.setFlightMode(setOneWayDirection);
            //Fill flight origin
            this.setFlightOrigin(strFlightOrigin);
            //Fill flight destination
            this.setFlightDestination(strFlightDestination);
            //Fill departing date
            this.setDepartingDate(strDepartingDate);
            //Fill returning date
            if (!setOneWayDirection)
            {
                this.setReturningDate(strReturningDate);
            }
            //Fill number of adults
            this.setAdultsCount(strAdultsCount);
            //Fill number of children
            this.setChildrenCount(strChildrenCount);
            //Click Advanced options hyperlink
            this.clickAdvancedOptions();
            //Fill flight class
            this.setFlightClass(strFlightClass);
            //Click Search button
            this.clickSearchButton();
        }
    }
}