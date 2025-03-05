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
    public class CheckoutCompletedPage
    {
        private IWebDriver driver;
        ////CheckoutCompletedPage
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("input[class*='order-completed']")));
        //string orderProcessedExpected = "Your order has been successfully processed!";
        //string orderProcessedActual = driver.FindElement(By.CssSelector(".title")).Text;
        //Assert.AreEqual(orderProcessedExpected, orderProcessedActual);
        //string orderNumber = driver.FindElement(By.CssSelector("ul[class='details'] li:nth-child(1)")).Text;
        //TestContext.Progress.WriteLine(orderNumber);
        //string[] splittedText = orderNumber.Split(" ");
        //string trimmedorderNumber = splittedText[2];
        //TestContext.Progress.WriteLine(trimmedorderNumber);
        //driver.FindElement(By.CssSelector("li a[href*='orderdetails']")).Click();

        public CheckoutCompletedPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "input[class*='order-completed']")]
        private IWebElement orderCompletedContinueButton;

        [FindsBy(How = How.CssSelector, Using = ".title")]
        private IWebElement titlePage;

        [FindsBy(How = How.CssSelector, Using = "ul[class='details'] li:nth-child(1)")]
        private IWebElement orderNumber;

        [FindsBy(How = How.CssSelector, Using = "li a[href*='orderdetails']")]
        private IWebElement orderDetailsLink;

        public IWebElement titlePageElement()
        {
            return titlePage;
        }
        public IWebElement orderNumberElement()
        {
            return orderNumber;
        }
        public void OrderCompletedContinue()
        {
            orderCompletedContinueButton.Click();
        }
        public OrderDetailsPage GoToOrderDetails()
        {
            orderDetailsLink.Click();
            WaitForOderDetailsPageToBeVisible();
            return new OrderDetailsPage(driver);
        }
        public void WaitForOderDetailsPageToBeVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".order-number")));
        }

    }
}
