using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFramework.pageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;

        /*
        string username = "ginautouser@maildrop.cc";  //"autouser1@maildrop.cc"; 
        string password = "Welcome1";

        //Login 
        driver.FindElement(By.CssSelector(".ico-login")).Click();
        driver.FindElement(By.Id("Email")).SendKeys(username);
        driver.FindElement(By.Id("Password")).SendKeys(password);
        driver.FindElement(By.CssSelector("input[value='Log in']")).Click();
        */
        public LoginPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        // Page object factory
        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement eMail;

        public IWebElement getEmail()
        {
            return eMail;
        }

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement password;
        public IWebElement getPassword()
        {
            return password;
        }
        
        [FindsBy(How=How.CssSelector, Using = "input[value='Log in']")]
        private IWebElement loginButton;

        public ProductsPage ValidLogin(string user, string pass)
        {
            eMail.SendKeys(user);
            password.SendKeys(pass);
            loginButton.Click();
            return new ProductsPage(driver);
        }


    }
}
