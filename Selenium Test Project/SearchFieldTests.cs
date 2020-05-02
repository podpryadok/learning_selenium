using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Selenium_Test_Project.Helpers;
using Selenium_Test_Project.Page_objects;

namespace Selenium_Test_Project
{
    class SearchFieldTests
    {
        IWebDriver driver;
        WebElemetsHelpers weHelpers;
        SearchResultsPageObjects SearchResultsPageObjects;
        MainPageObjects mainPageObjects;
        Expectant expectant;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            weHelpers = new WebElemetsHelpers(driver);
            SearchResultsPageObjects = new SearchResultsPageObjects();
            mainPageObjects = new MainPageObjects();
            expectant = new Expectant(driver);

            //Set fullscreen
            driver.Manage().Window.Maximize();

            //Set the URL
            driver.Url = "http://automationpractice.com/index.php";
        }

        [Test]
        public void SearchFieldIsDisplayed()
        {
            //Find the search field and verify it is displayed
            bool searchFieldIsDisplayed = weHelpers.Displayed(mainPageObjects.SearchField);

            Assert.IsTrue(searchFieldIsDisplayed);
        }

        [Test]
        public void SearchWithOneResult()
        {
            //Search the item
            weHelpers.SendKey(mainPageObjects.SearchField, "Blouse");
            weHelpers.Submit(mainPageObjects.SearchField);

            //Wait when the page load
            expectant.WaitForPage(SearchResultsPageObjects.SearchResultItemName);

            //Verify the item name
            string returnText = weHelpers.ReturnText(SearchResultsPageObjects.SearchResultItemName);

            Assert.AreEqual("Blouse", returnText);
        }

        [Test]
        public void SearchWithManyResults()
        {
            //Search the items
            weHelpers.SendKey(mainPageObjects.SearchField, "Dress");
            weHelpers.Submit(mainPageObjects.SearchField);

            //Wait when the page load
            expectant.WaitForPage(SearchResultsPageObjects.CounterAreResults);

            //Find the text with the count of result and cut the text for taking the number of it
            string numberOfResults = weHelpers.ReturnText(SearchResultsPageObjects.CounterAreResults).Remove(1);

            string countOfResults = driver.FindElements(By.XPath("//*[@id='center_column']/ul/li")).Count.ToString();            

            //Verify the count of items
            Assert.AreEqual(countOfResults, numberOfResults);
        }

        [Test]
        public void ClickOnSearchButton()
        {
            //Entered the text and click on the button
            weHelpers.SendKey(mainPageObjects.SearchField, "T-shirt");
            weHelpers.Click(mainPageObjects.SearchButton);

            //Wait when the page load
            expectant.WaitForPage(SearchResultsPageObjects.SearchResult);

            //Verify the search result
            Assert.IsTrue(weHelpers.Displayed(SearchResultsPageObjects.SearchResult));
        }
        
        [Test]
        public void EmptySearch()
        {
            //Click on the search button with empty search field
            weHelpers.Click(mainPageObjects.SearchButton);

            //Wait when the page load
            expectant.WaitForPage(SearchResultsPageObjects.ErrorMessage);

            //Verify error message
            Assert.IsTrue(weHelpers.Displayed(SearchResultsPageObjects.ErrorMessage));
            //Verify error text message
            Assert.AreEqual("Please enter a search keyword", weHelpers.ReturnText(SearchResultsPageObjects.ErrorMessage));
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
