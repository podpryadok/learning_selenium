using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Test_Project.Helpers
{
    class DropdownElementsHelpers
    {
        IWebDriver driver;

        public DropdownElementsHelpers(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement FindElement(string xpath)
        {
            IWebElement element = driver.FindElement(By.XPath(xpath));
            return element;
        }

        private SelectElement SelectTheElement(IWebElement element)
        {
            SelectElement selectElement = new SelectElement(element);
            return selectElement;
        }

        /*This command selects an option of a dropdown based on the text of the option.*/
        public void SelectByText(string xpath, string selectedText)
        {
            IWebElement element = FindElement(xpath);
            SelectElement selectElement = SelectTheElement(element);
            selectElement.SelectByText(selectedText);
        }

        /*This command is used to select an option based on its index. Index of dropdown starts at 0.*/
        public void SelectByIndex(string xpath, int index)
        {
            IWebElement element = FindElement(xpath);
            SelectElement selectElement = SelectTheElement(element);
            selectElement.SelectByIndex(index);
        }

        /*This command is used to select an option based on its option value.*/
        public void SelectByValue(string xpath, string value)
        {
            IWebElement element = FindElement(xpath);
            SelectElement selectElement = SelectTheElement(element);
            selectElement.SelectByValue(value);
        }

        /*This command is used to retrieve the list of options displayed in a dropdown.*/
        public IList<IWebElement> ListOfOptions(string xpath)
        {
            IWebElement element = FindElement(xpath);
            SelectElement selectElement = SelectTheElement(element);
            IList<IWebElement> options = selectElement.Options;
            return options;
        }

        /*This command is used to identify if a dropdown is a multi select dropdown;
         *A multi select dropdown enables user to select more than one option in a dropdown at a time. 
         *This command returns a Boolean value.*/
         public bool IsMulteple(string xpath)
        {
            IWebElement element = FindElement(xpath);
            SelectElement selectElement = SelectTheElement(element);
            bool result = selectElement.IsMultiple;
            return result;
        }

        /*This command is used in multi select dropdowns. 
         *It clears the options that have already been selected.*/
         public void DeSelectAll(string xpath)
        {
            IWebElement element = FindElement(xpath);
            SelectElement selectElement = SelectTheElement(element);
            selectElement.DeselectAll();
        }

        /*This command deselects an already selected value using its index.*/
        public void DeselectByIndex(string xpath, int index)
        {
            IWebElement element = FindElement(xpath);
            SelectElement selectElement = SelectTheElement(element);

            IList<IWebElement> allSelectedOptions = selectElement.AllSelectedOptions;
            bool indexIsEnebled = allSelectedOptions[index].Enabled;

            if (indexIsEnebled)
            {
                selectElement.DeselectByIndex(index);
            }
            else
            {
                throw new System.InvalidOperationException($"The option №{index} is not selected");
            }
        }

        /*This command deselects an already selected value using its value.*/
        public void DeselectByValue(string xpath, string value)
        {
            IWebElement element = FindElement(xpath);
            SelectElement selectElement = SelectTheElement(element);

            IList<IWebElement> allSelectedOptions = selectElement.AllSelectedOptions;
            bool indexIsEnebled = false;

            for (int i = 0; i < allSelectedOptions.Count; i++)
            {
                if(allSelectedOptions[i].Text == value)
                { 
                    int index = i;
                    indexIsEnebled = allSelectedOptions[index].Enabled;
                    break;
                }
            }

            if (indexIsEnebled)
            {
                selectElement.DeselectByValue(value);
            }
            else
            {
                throw new System.InvalidOperationException($"The option '{value}' is not selected");
            }
        }

        /*This command deselects an already selected value using its text.*/
        public void DeselectedByText(string xpath, string text)
        {
            IWebElement element = FindElement(xpath);
            SelectElement selectElement = SelectTheElement(element);

            IList<IWebElement> allSelectedOptions = selectElement.AllSelectedOptions;
            bool indexIsEnebled = false;

            for (int i = 0; i < allSelectedOptions.Count; i++)
            {
                if (allSelectedOptions[i].Text == text)
                {
                    int index = i;
                    indexIsEnebled = allSelectedOptions[index].Enabled;
                    break;
                }
            }

            if (indexIsEnebled)
            {
                selectElement.DeselectByValue(text);
            }
            else
            {
                throw new System.InvalidOperationException($"The option '{text}' is not selected");
            }
        }
    }
}