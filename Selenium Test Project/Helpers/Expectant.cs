using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Test_Project.Helpers
{
    class Expectant
    {
        public void WaitForPage(string xpath, IWebDriver driver)
        {
            //Wait when the page load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath(xpath)));
        }
    }
}
