using DemoFramework.utilities;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using DemoFramework.pageObjects;

namespace DemoFramework.tests
{
    public class Search: Base
    {
        [Test, Category("Smoke")]
        public void SearchOnStore()
        {

            LoginPage loginpage = new LoginPage(getDriver());

            JsonReader jsonReader = new JsonReader();
            string qToSearch = jsonReader.GetTextToSearch();
            loginpage.getSearchTextField().SendKeys(qToSearch);
            loginpage.ClickSearchBox();
            string querySearched = loginpage.getSearchedText().GetAttribute("value"); 

            Assert.AreEqual(qToSearch, querySearched);
        }
    }
}
