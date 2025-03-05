using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFramework.pageObjects
{
    public class OrderDetailsPage
    {
        private IWebDriver driver;
        ////OrderDetailsPage
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".order-number")));
        //string orderInformation = driver.FindElement(By.CssSelector(".order-number")).Text;
        //string[] splitOrderInfo = orderInformation.Split(" ");
        //string trimmedOrderInfo = splitOrderInfo[1];
        //StringAssert.Contains(trimmedorderNumber, trimmedOrderInfo);
        //string productOrderInfo = driver.FindElement(By.CssSelector("td[class*='a-left'] div[class='attributes']")).Text;
        //Assert.AreEqual(productConfirmed, productOrderInfo);
        //TestContext.Progress.WriteLine(trimmedOrderInfo);
        //TestContext.Progress.WriteLine(productOrderInfo);

        public OrderDetailsPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".order-number")]
        private IWebElement orderNumber;
        [FindsBy(How = How.CssSelector, Using = "td[class*='a-left'] div[class='attributes']")]
        private IWebElement productOrderInfo;
        public IWebElement orderNumberElement()
        {  
            return orderNumber; 
        }
        public IWebElement productOrderInfoElement()
        {
            return productOrderInfo;
        }

    }
}
