using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Test_Project
{
    public class MainPageTests
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
        public void OpenSite()
        {
            //Find the logo and verify it is displayed
            string logo = "//*[@id='header_logo']";
            bool logoDisplayed = weHelpers.Displayed(logo, driver);

            Assert.AreEqual(true, logoDisplayed);
        }

        [Test]
        public void SelectItem()
        {
            //Find the blouse item, click on it and verify the item page is opened
            string blouse = "//*[@id='homefeatured']/li[2]";
            weHelpers.Click(blouse, driver);
            string webElementTitle = "//*[@id='center_column']/div/div/div[3]/h1";
            //Wait the element is appears
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath(webElementTitle)));

            //Verify the page by the item name
            string title = weHelpers.ReturnText(webElementTitle, driver);

            Assert.AreEqual(expected: "Blouse", actual: title);
            
        }

        [Test]
        public void SetColor()
        {
            //Checking the color the item
            string mainBarMenu = "//*[@id='header']/div[2]/div/div/nav/div[1]";
            string barColor = weHelpers.GetRGBA(mainBarMenu, driver);

            Assert.AreEqual("rgba(119, 119, 119, 1)", barColor);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}