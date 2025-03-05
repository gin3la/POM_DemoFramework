using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFramework.pageObjects
{
    public class ShoppingCartPage
    {
        private IWebDriver driver;

        //ShoppingCartPage
        //string productDetails = driver.FindElement(By.CssSelector("td[class='product'] div[class='attributes']")).Text;
        //TestContext.Progress.WriteLine(productDetails);
        //driver.FindElement(By.Id("termsofservice")).Click();
        //driver.FindElement(By.Name("checkout")).Click();
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".checkout-page")));

        public ShoppingCartPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "td[class='product'] div[class='attributes']")]
        private IWebElement productDetails;

        [FindsBy(How = How.Id, Using = "termsofservice")]
        private IWebElement termsOfService;

        [FindsBy(How = How.Name, Using = "checkout")]
        private IWebElement checkoutButton;
        public IWebElement GetProductDetails()
        {
            return productDetails;
        }
        public void CheckTermOfService()
        {
            termsOfService.Click();
        }

        public CheckOutPage CheckOut()
        {
            checkoutButton.Click();
            WaitForCheckOutPage(); 
            return new CheckOutPage(driver);
        }

        public void WaitForShoppingCartHeader()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='page-title']//h1[text()= 'Shopping cart']")));
        }
        public void WaitForCheckOutPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".checkout-page")));
        }

    }
}
