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
    public class ProductPage_Sneakers
    {
        private IWebDriver driver;

        //ProductSneakersPage
        //// product details page
        //IWebElement sizeDropdown = driver.FindElement(By.Id("product_attribute_28_7_10"));
        //SelectElement size = new SelectElement(sizeDropdown);
        //size.SelectByText("9");
        //driver.FindElement(By.CssSelector("span[title='Black']")).Click();
        //driver.FindElement(By.Id("add-to-cart-button-28")).Click();

        //// click on shopping cart link on notification bar
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#bar-notification")));
        //driver.FindElement(By.LinkText("shopping cart")).Click();
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div.shopping-cart-page")));
        public ProductPage_Sneakers(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "product_attribute_28_7_10")]
        private IWebElement sneakerSize;

        [FindsBy(How = How.CssSelector, Using = "span[title='Black']")]
        private IWebElement sneakerColor;

        [FindsBy(How = How.Id, Using = "add-to-cart-button-28")]
        private IWebElement addtoCartButton;

        [FindsBy(How = How.LinkText, Using = "shopping cart")]
        private IWebElement shoppingCartLink;

        public IWebElement sneakerSizeSelect()
        {
            return sneakerSize;
        }
        
        public void sneakerColorSelect()
        {
            sneakerColor.Click();
        }

        public void AddToCart()
        {
            addtoCartButton.Click();
        }

        public void WaitForShoppingCartLinkOnBar()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#bar-notification")));
        }
        public ShoppingCartPage GoToShoppingCart()
        {
            shoppingCartLink.Click();
            return new ShoppingCartPage(driver);
        }


    }
}
