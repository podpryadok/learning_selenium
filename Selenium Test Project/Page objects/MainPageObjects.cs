using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Test_Project.Page_objects
{
    class MainPageObjects
    {
        public string logo = "//*[@id='header_logo']";
        public string blouse = "//*[@id='homefeatured']/li[2]";
        public string mainBarMenu = "//*[@id='header']/div[2]/div/div/nav/div[1]";
        public string searchField = "//*[@id='search_query_top']";
        public string searchButton = "//*[@id='searchbox']/button"; 
    }
}
