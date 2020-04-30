using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Test_Project.Page_objects
{
    class SearchResultsPageObjects
    {
        public string searchResultItemName = "//*[@id='center_column']/ul/li/div/div[2]/h5";
        public string counterAreResults = "//*[@id='center_column']/h1/span[2]";
        public string searchResult = "//*[@id='center_column']/ul/li";
        public string errorMessage = "//*[@id='center_column']/p";
    }
}
