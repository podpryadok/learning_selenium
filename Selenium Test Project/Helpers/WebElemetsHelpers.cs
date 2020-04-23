using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Selenium_Test_Project
{
    class WebElemetsHelpers
    {
        private IWebElement FindElement(string xpath, IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(xpath));
            return element;
        }

        /*This command is used to click on a Webelement.
        *For the element to be clickable, the element must be visible on the webpage. 
        *This command is used for checkbox and radio button operations as well.*/
        public void Click(string xpath, IWebDriver driver)
        {
            IWebElement element = FindElement(xpath, driver);
            element.Click();
        }

        //This command is specifically used for clearing the existing contents of textboxes.
        public void Clear(string xpath, IWebDriver driver)
        {
            IWebElement element = FindElement(xpath, driver);
            element.Clear();
        }

        /*This command is used to input a value onto text boxes.
        *The value to be entered must be passed as a parameter to*/
        public void SendKey(string xpath, IWebDriver driver, string value)
        {
            IWebElement element = FindElement(xpath, driver);
            element.SendKeys(value);
        }

        /*This command returns the innertext of a Webelement.
        *This command returns a string value as a result.*/
        public string ReturnText(string xpath, IWebDriver driver)
        {
            IWebElement element = FindElement(xpath, driver);
            string result = element.Text;
            return result;
        }

        /*This command is used to identify if a specific element is displayed on the webpage. 
         * This command returns a Boolean value; true or false depending on the visibility of web element.*/
        public bool Displayed(string xpath, IWebDriver driver)
        {
            IWebElement element = FindElement(xpath, driver);
            bool result = element.Displayed;
            return result;
        }

        /*This command is used to identify if a particular web element is enabled on the web page. 
         *This command returns a Boolean value; true or false as a result.*/
        public bool Enebled(string xpath, IWebDriver driver)
        {
            IWebElement element = FindElement(xpath, driver);
            bool result = element.Enabled;
            return result;
        }

        /*This command is used to identify if a particular web element is selected.
         *This command is used for checkboxes,radio buttons, and select operations.*/
         public bool IsSelected(string xpath, IWebDriver driver)
        {
            IWebElement element = FindElement(xpath, driver);
            bool result = element.Selected;
            return result;
        }

        /*This command is similar to click command, The difference lies in whether the HTML form has a button with the type Submit.
         *While the click command clicks on any button, submit command clicks on the only the buttons with type submit.*/
         public void Submit(string xpath, IWebDriver driver)
        {
            IWebElement element = FindElement(xpath, driver);
            element.Submit();
        }

        /*This command returns the HTML tag of a web element.
         *It returns a string value as the result.*/
         public string TagName(string xpath, IWebDriver driver)
        {
            IWebElement element = FindElement(xpath, driver);
            string result = element.TagName;
            return result;
        }

        /*This method is used to return the color of a web element on the form of a rgba string (Red,Green,Blue, and Alpha).*/
        public string GetRGBA(string xpath, IWebDriver driver)
        {
            IWebElement element = FindElement(xpath, driver);
            string result = element.GetCssValue("color");
            return result;
        }
    }
}
