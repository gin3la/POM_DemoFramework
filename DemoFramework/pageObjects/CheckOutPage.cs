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
    public class CheckOutPage
    {
        private IWebDriver driver;

        ////Checkout page
        //driver.FindElement(By.CssSelector("input[onclick*='Billing.save()']")).Click();
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[onclick*='Shipping.save()']"))).Click();
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[onclick*='ShippingMethod.save()']")));
        //driver.FindElement(By.Id("shippingoption_1")).Click();
        //driver.FindElement(By.CssSelector("input[onclick*='ShippingMethod.save()']")).Click();
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[onclick*='PaymentMethod.save()")));
        //driver.FindElement(By.Id("paymentmethod_3")).Click();
        //driver.FindElement(By.CssSelector("input[onclick*='PaymentMethod.save()")).Click();
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[onclick*='PaymentInfo.save()']")));
        //driver.FindElement(By.Id("PurchaseOrderNumber")).SendKeys("35346346");
        //driver.FindElement(By.CssSelector("input[onclick*='PaymentInfo.save()']")).Click();
        ////scroll down
        //IWebElement scrollToTotal = driver.FindElement(By.CssSelector("input[onclick='ConfirmOrder.save()']"));
        //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        //js.ExecuteScript("arguments[0].scrollIntoView(true);", scrollToTotal);
        ////assert product details
        //string productConfirmed = driver.FindElement(By.CssSelector("tbody tr td:nth-child(2) div[class='attributes']")).Text;
        //TestContext.Progress.WriteLine(productConfirmed);
        //Assert.AreEqual(productDetails, productConfirmed);
        //driver.FindElement(By.CssSelector("input[onclick='ConfirmOrder.save()']")).Click();

        public CheckOutPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "input[onclick*='Billing.save()']")]
        private IWebElement billingContinueButton;

        [FindsBy(How = How.CssSelector, Using = "input[onclick*='Shipping.save()']")]
        private IWebElement shippingAddressSaveButton;

        [FindsBy(How = How.CssSelector, Using = "input[onclick*='ShippingMethod.save()']")]
        private IWebElement shippingMethodSaveButton;

        [FindsBy(How = How.Id, Using = "shippingoption_1")]
        private IWebElement shippingOption1Button;

        [FindsBy(How = How.CssSelector, Using = "input[onclick*='PaymentMethod.save()")]
        private IWebElement paymentMethodSaveButton;

        [FindsBy(How = How.Id, Using = "paymentmethod_3")]
        private IWebElement paymentMethod3Button;

        [FindsBy(How = How.CssSelector, Using = "input[onclick*='PaymentInfo.save()']")]
        private IWebElement paymentInfoSaveButton;

        [FindsBy(How = How.Id, Using = "PurchaseOrderNumber")]
        private IWebElement purchaseOrderNumberField;

        [FindsBy(How = How.CssSelector, Using = "input[onclick='ConfirmOrder.save()']")]
        private IWebElement confirmOrderButton;

        [FindsBy(How = How.CssSelector, Using = "tbody tr td:nth-child(2) div[class='attributes']")]
        private IWebElement confirmedProductDetails;

        public void BillingContinue()
        {
            billingContinueButton.Click();
            WaitForShippingToBeVisible();
        }
        public void WaitForShippingToBeVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[onclick*='Shipping.save()']")));
        }
        
        public void ShippingAddressSave()
        {
            shippingAddressSaveButton.Click();
            WaitForShippingMethodToBeVisible();
        }
        public void WaitForShippingMethodToBeVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[onclick*='ShippingMethod.save()']")));
        }
        public void SelectShippingOption()
        {
            shippingOption1Button.Click();
            shippingMethodSaveButton.Click();
            WaitForPaymentMethodToBeVisible();
        }
        public void WaitForPaymentMethodToBeVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[onclick*='PaymentMethod.save()")));
        }
        public void SelectPaymentMethod()
        {
            paymentMethod3Button.Click();
            paymentMethodSaveButton.Click();
            WaitForPaymentInfoToBeVisible();
        }
        public void WaitForPaymentInfoToBeVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[onclick*='PaymentInfo.save()']")));
        }

        public IWebElement purchaseOrderNumber()
        {
            return purchaseOrderNumberField;
        }
        public void PaymentInfoContinue()
        {
            paymentInfoSaveButton.Click();
            WaitForOrderReviewToBeVisible();
        }
        public void WaitForOrderReviewToBeVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='order-review-data']")));
        }
        public IWebElement confirmOrderElement()
        {
            return confirmOrderButton;
        }

        public IWebElement ProductDetails()
        {
            return confirmedProductDetails;
        }

        public void ScrollToElementJavaScriptExecutor(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public CheckoutCompletedPage ConfirmOrder()
        {
            confirmOrderButton.Click();
            WaitForCheckOutPageCompleteToBeVisible();
            return new CheckoutCompletedPage(driver);
        }
        public void WaitForCheckOutPageCompleteToBeVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("input[class*='order-completed']")));
        }

    }
}
