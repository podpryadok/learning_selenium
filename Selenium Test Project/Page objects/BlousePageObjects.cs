using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Test_Project.Page_objects
{
    class BlousePageObjects
    {
        private string webElementTitle = "//*[@id='center_column']/div/div/div[3]/h1";

        public string WebElementTitle { get => webElementTitle; set => webElementTitle = value; }
    }
}
