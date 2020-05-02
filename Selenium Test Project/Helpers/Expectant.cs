using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Test_Project.Helpers
{
    class Expectant
    {
        IWebDriver driver;

        public Expectant(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForPage(string xpath)
        {
            //Wait when the page load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath(xpath)));
        }
    }
}
