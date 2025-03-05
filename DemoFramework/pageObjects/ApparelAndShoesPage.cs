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
    public class ApparelAndShoesPage
    {
        private IWebDriver driver;
        //By breadcrumb = By.CssSelector(".breadcrumb");

        //Go to Apparel & Shoes  menu
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".breadcrumb")));

        ////select page dropdown
        //IWebElement dropdownDisplay = driver.FindElement(By.Name("products-pagesize"));
        //SelectElement s = new SelectElement(dropdownDisplay);
        //s.SelectByText("12");
        //string selectedOption = driver.FindElement(By.Name("products-pagesize")).GetAttribute("value");
        //StringAssert.Contains("12", selectedOption);

        //// select product
        //driver.FindElement(By.CssSelector(".product-title a[href='/blue-and-green-sneaker']")).Click();
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".breadcrumb")));

        public ApparelAndShoesPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "products-pagesize")]
        private IWebElement dropdownPageSize;

        public IWebElement dropdownPageSizeSelect()
        {
            return dropdownPageSize;
        }

        [FindsBy(How = How.CssSelector, Using = ".product-title a[href='/blue-and-green-sneaker']")]
        private IWebElement blueGreenSneakerLink;

        public ProductPage_Sneakers SelectBlueGreenSneaker()
        {
            blueGreenSneakerLink.Click();
            return new ProductPage_Sneakers(driver);
        }

        //public By getBreadcrumb()
        //{
        //    return breadcrumb;
        //}

        //public void WaitForPageDisplay()
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
        //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(getBreadcrumb()));
        //}


        

    }
}
