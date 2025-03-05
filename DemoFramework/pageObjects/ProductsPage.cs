using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;


namespace DemoFramework.pageObjects
{
    public class ProductsPage
    {
        private IWebDriver driver;
        By logoutLink = By.LinkText("Log out");

        //Products page
        //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Log out")));

        //    string userLogin = driver.FindElement(By.CssSelector("div[class='header-links'] ul li a[class='account']")).Text;
        //TestContext.Progress.WriteLine(userLogin);
        //    Assert.AreEqual(username, userLogin);
        //Go to Apparel & Shoes  menu
        //driver.FindElement(By.CssSelector("ul[class='top-menu'] li a[href='/apparel-shoes']")).Click();

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

       
        [FindsBy(How = How.CssSelector, Using = "div[class='header-links'] ul li a[class='account']")]
        private IWebElement userLogin;
        public IWebElement getuserLogin()
        {
            return userLogin;
        }

        public By getLogoutLink()
        {
            return logoutLink;
        }
        public void WaitForLogoutDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(getLogoutLink()));

        }

        [FindsBy(How = How.CssSelector, Using = "ul[class='top-menu'] li a[href='/apparel-shoes']")]
        private IWebElement apparelAndShoesLink;

        public ApparelAndShoesPage apparelAndShoesMenu()
        {
            apparelAndShoesLink.Click();
            return new ApparelAndShoesPage(driver);
        }

    }
}
