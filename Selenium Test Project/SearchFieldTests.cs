using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Selenium_Test_Project.Page_objects;

namespace Selenium_Test_Project
{
    class SearchFieldTests
    {
        IWebDriver driver;
        WebElemetsHelpers weHelpers;
        SearchResultsPageObjects SearchResultsPageObjects;
        MainPageObjects mainPageObjects;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            weHelpers = new WebElemetsHelpers();
            SearchResultsPageObjects = new SearchResultsPageObjects();
            mainPageObjects = new MainPageObjects();

            //Set fullscreen
            driver.Manage().Window.Maximize();

            //Set the URL
            driver.Url = "http://automationpractice.com/index.php";
        }

        [Test]
        public void SearchFieldIsDisplayed()
        {
            //Find the search field and verify it is displayed
            bool searchFieldIsDisplayed = weHelpers.Displayed(mainPageObjects.searchField, driver);

            Assert.IsTrue(searchFieldIsDisplayed);
        }

        [Test]
        public void SearchWithOneResult()
        {
            //Search the item
            weHelpers.SendKey(mainPageObjects.searchField, driver, "Blouse");
            weHelpers.Submit(mainPageObjects.searchField, driver);

            //Wait when the page load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath(SearchResultsPageObjects.searchResultItemName)));

            //Verify the item name
            string returnText = weHelpers.ReturnText(SearchResultsPageObjects.searchResultItemName, driver);

            Assert.AreEqual("Blouse", returnText);
        }

        [Test]
        public void SearchWithManyResults()
        {
            //Search the items
            weHelpers.SendKey(mainPageObjects.searchField, driver, "Dress");
            weHelpers.Submit(mainPageObjects.searchField, driver);

            //Find the text with the count of result and cut the text for taking the number of it
            string numberOfResults = weHelpers.ReturnText(SearchResultsPageObjects.counterAreResults, driver).Remove(1);

            //Verify the count of items
            Assert.AreEqual("7", numberOfResults);
        }

        [Test]
        public void ClickOnSearchButton()
        {
            //Entered the text and click on the button
            weHelpers.SendKey(mainPageObjects.searchField, driver, "T-shirt");
            weHelpers.Click(mainPageObjects.searchButton, driver);

            //Wait when the page load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath(SearchResultsPageObjects.searchResult)));

            //Verify the search result
            Assert.IsTrue(weHelpers.Displayed(SearchResultsPageObjects.searchResult, driver));
        }
        
        [Test]
        public void EmptySearch()
        {
            //Click on the search button with empty search field
            weHelpers.Click(mainPageObjects.searchButton, driver);

            //Verify error message
            Assert.IsTrue(weHelpers.Displayed(SearchResultsPageObjects.errorMessage, driver));
            //Verify error text message
            Assert.AreEqual("Please enter a search keyword", weHelpers.ReturnText(SearchResultsPageObjects.errorMessage, driver));
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
