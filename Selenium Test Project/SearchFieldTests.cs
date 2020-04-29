using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Test_Project
{
    class SearchFieldTests
    {
        IWebDriver driver;
        WebElemetsHelpers weHelpers;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            weHelpers = new WebElemetsHelpers();

            //Set fullscreen
            driver.Manage().Window.Maximize();

            //Set the URL
            driver.Url = "http://automationpractice.com/index.php";
        }

        [Test]
        public void SearchFieldIsDisplayed()
        {
            //Find the search field and verify it is displayed
            string searchField = "//*[@id='searchbox']";
            bool searchFieldIsDisplayed = weHelpers.Displayed(searchField, driver);

            Assert.IsTrue(searchFieldIsDisplayed);
        }

        [Test]
        public void SearchWithOneResult()
        {
            //Search the item
            string searchField = "//*[@id='search_query_top']";
            weHelpers.SendKey(searchField, driver, "Blouse");
            weHelpers.Submit(searchField, driver);

            string searchResultItemName = "//*[@id='center_column']/ul/li/div/div[2]/h5";
            //Wait when the page load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath(searchResultItemName)));

            //Verify the item name
            string returnText = weHelpers.ReturnText(searchResultItemName, driver);

            Assert.AreEqual("Blouse", returnText);
        }

        [Test]
        public void SearchWithManyResults()
        {
            //Search the items
            string searchField = "//*[@id='search_query_top']";
            weHelpers.SendKey(searchField, driver, "Dress");
            weHelpers.Submit(searchField, driver);

            //Find the text with the count of result and cut the text for taking the number of it
            string counterAreResults = "//*[@id='center_column']/h1/span[2]";
            string numberOfResults = weHelpers.ReturnText(counterAreResults, driver).Remove(1);

            //var allItems = "//*[@id='center_column']/ul";
            //IWebElement webElement = driver.FindElement(By.XPath(allItems));

            Assert.AreEqual("7", numberOfResults);
        }

        [Test]
        public void ClickOnSearchButton()
        {
            string searchField = "//*[@id='search_query_top']";
            string searchButton = "//*[@id='searchbox']/button";
            weHelpers.SendKey(searchField, driver, "T-shirt");
            weHelpers.Click(searchButton, driver);

            string searchResult = "//*[@id='center_column']/ul/li";
            //Wait when the page load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath(searchResult)));

            Assert.IsTrue(weHelpers.Displayed(searchResult, driver));
        }

        [Test]
        public void EmptySearch()
        {
            string searchButton = "//*[@id='searchbox']/button";
            weHelpers.Click(searchButton, driver);

            string errorMessage = "//*[@id='center_column']/p";
            Assert.IsTrue(weHelpers.Displayed(errorMessage, driver));

            Assert.AreEqual("Please enter a search keyword", weHelpers.ReturnText(errorMessage, driver));
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
