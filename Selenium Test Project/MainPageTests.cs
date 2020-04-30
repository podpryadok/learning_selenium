using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium_Test_Project.Page_objects;

namespace Selenium_Test_Project
{
    public class MainPageTests
    {
        IWebDriver driver;
        WebElemetsHelpers weHelpers;
        MainPageObjects mainPageObjects;
        BlousePageObjects blousePageObjects;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            weHelpers = new WebElemetsHelpers();
            mainPageObjects = new MainPageObjects();
            blousePageObjects = new BlousePageObjects();

            //Set fullscreen
            driver.Manage().Window.Maximize();

            //Set the URL
            driver.Url = "http://automationpractice.com/index.php";
        }

        [Test]
        public void OpenSite()
        {
            //Find the logo and verify it is displayed
            bool logoDisplayed = weHelpers.Displayed(mainPageObjects.logo, driver);

            Assert.AreEqual(true, logoDisplayed);
        }

        [Test]
        public void SelectItem()
        {
            //Find the blouse item, click on it and verify the item page is opened
            weHelpers.Click(mainPageObjects.blouse, driver);

            //Wait the element is appears
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath(blousePageObjects.webElementTitle)));

            //Verify the page by the item name
            string title = weHelpers.ReturnText(blousePageObjects.webElementTitle, driver);

            Assert.AreEqual(expected: "Blouse", actual: title);
            
        }

        [Test]
        public void SetColor()
        {
            //Checking the color the item
            string barColor = weHelpers.GetRGBA(mainPageObjects.mainBarMenu, driver);

            Assert.AreEqual("rgba(119, 119, 119, 1)", barColor);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}