using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Test_Project.Page_objects
{
    class SearchResultsPageObjects
    {
        private string searchResultItemName = "//*[@id='center_column']/ul/li/div/div[2]/h5";
        private string counterAreResults = "//*[@id='center_column']/h1/span[2]";
        private string searchResult = "//*[@id='center_column']/ul/li";
        private string errorMessage = "//*[@id='center_column']/p";

        public string SearchResultItemName { get => searchResultItemName; set => searchResultItemName = value; }
        public string CounterAreResults { get => counterAreResults; set => counterAreResults = value; }
        public string SearchResult { get => searchResult; set => searchResult = value; }
        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }
    }
}
