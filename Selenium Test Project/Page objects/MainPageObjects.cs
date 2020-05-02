using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Test_Project.Page_objects
{
    class MainPageObjects
    {
        private string logo = "//*[@id='header_logo']";
        private string blouse = "//*[@id='homefeatured']/li[2]";
        private string mainBarMenu = "//*[@id='header']/div[2]/div/div/nav/div[1]";
        private string searchField = "//*[@id='search_query_top']";
        private string searchButton = "//*[@id='searchbox']/button";

        public string Logo { get => logo; set => logo = value; }
        public string Blouse { get => blouse; set => blouse = value; }
        public string MainBarMenu { get => mainBarMenu; set => mainBarMenu = value; }
        public string SearchField { get => searchField; set => searchField = value; }
        public string SearchButton { get => searchButton; set => searchButton = value; }
    }
}
