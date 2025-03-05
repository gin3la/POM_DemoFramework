using DemoFramework.pageObjects;
using DemoFramework.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using static System.Net.Mime.MediaTypeNames;

namespace DemoFramework.tests
{

    [Parallelizable(ParallelScope.Children)]
    public class E2ETest : Base
    {
        [Test, TestCaseSource("AddTestDataConfig"), Category("Regression")]
        [Parallelizable(ParallelScope.All)]
        public void EndToEndOrder(string user, string pass)
        {
            JsonReader jsonReader =new JsonReader();
            string dropdownPageSize = jsonReader.GetDropdownPageSize();
            string sneakerSizeToSelect = jsonReader.GetSneakerSizeToSelect();
            string purchaseOrderNumberFromJson = jsonReader.GetPurchaseOrderNumber();
            if (string.IsNullOrEmpty(dropdownPageSize) || string.IsNullOrEmpty(sneakerSizeToSelect) || string.IsNullOrEmpty(purchaseOrderNumberFromJson))
            {
                Assert.Fail("Key or value is not found in the JSON file.");
                return;
            }


            LoginPage loginPage = new LoginPage(getDriver());
            ProductsPage productsPage = loginPage.ValidLogin(user, pass);
            productsPage.WaitForLogoutDisplay();
            
            ApparelAndShoesPage apparelShoesPage = productsPage.apparelAndShoesMenu();
            WaitForPageDisplay();
            IWebElement dropdownDisplay = apparelShoesPage.dropdownPageSizeSelect();
            SelectElement s = new SelectElement(dropdownDisplay);
            s.SelectByText(dropdownPageSize);
            string selectedOption = apparelShoesPage.dropdownPageSizeSelect().GetAttribute("value");
            StringAssert.Contains(dropdownPageSize, selectedOption);

            ProductPage_Sneakers productSneakersPage = apparelShoesPage.SelectBlueGreenSneaker();
            WaitForPageDisplay();
            IWebElement sizeDropdown = productSneakersPage.sneakerSizeSelect();
            SelectElement size = new SelectElement(sizeDropdown);
            size.SelectByText(sneakerSizeToSelect);
            productSneakersPage.sneakerColorSelect();
            productSneakersPage.AddToCart();
            productSneakersPage.WaitForShoppingCartLinkOnBar();

            ShoppingCartPage shoppingCartPage = productSneakersPage.GoToShoppingCart();
            shoppingCartPage.WaitForShoppingCartHeader();
            string actualProductDetails = shoppingCartPage.GetProductDetails().Text;
            TestContext.Progress.WriteLine(actualProductDetails);
            shoppingCartPage.CheckTermOfService();

            CheckOutPage checkoutPage = shoppingCartPage.CheckOut();
            checkoutPage.BillingContinue();
            checkoutPage.ShippingAddressSave();
            checkoutPage.SelectShippingOption();
            checkoutPage.SelectPaymentMethod();
            checkoutPage.purchaseOrderNumber().SendKeys(purchaseOrderNumberFromJson);
            checkoutPage.PaymentInfoContinue();
            IWebElement scrollToTotal = checkoutPage.confirmOrderElement();
            checkoutPage.ScrollToElementJavaScriptExecutor(scrollToTotal);
            string productConfirmed = checkoutPage.ProductDetails().Text;
            TestContext.Progress.WriteLine(productConfirmed);
            Assert.AreEqual(actualProductDetails, productConfirmed); 

            CheckoutCompletedPage checkoutcompletePage = checkoutPage.ConfirmOrder();
            string orderProcessedExpected = "Your order has been successfully processed!";
            string orderProcessedActual = checkoutcompletePage.titlePageElement().Text;
            Assert.AreEqual(orderProcessedExpected, orderProcessedActual);
            string orderNumber = checkoutcompletePage.orderNumberElement().Text; 
            TestContext.Progress.WriteLine(orderNumber);
            string[] splittedText = orderNumber.Split(" ");
            string trimmedorderNumber = splittedText[2];
            TestContext.Progress.WriteLine(trimmedorderNumber);

            OrderDetailsPage orderDetailsPage = checkoutcompletePage.GoToOrderDetails();
            string orderInformation = orderDetailsPage.orderNumberElement().Text;
            string[] splitOrderInfo = orderInformation.Split(" ");
            string trimmedOrderInfo = splitOrderInfo[1];
            StringAssert.Contains(trimmedorderNumber, trimmedOrderInfo);
            string productOrderInfo = orderDetailsPage.productOrderInfoElement().Text; 
            Assert.AreEqual(productConfirmed, productOrderInfo);
            TestContext.Progress.WriteLine(trimmedOrderInfo);
            TestContext.Progress.WriteLine(productOrderInfo);

        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"));
            yield return new TestCaseData(getDataParser().extractData("username_valid"), getDataParser().extractData("password_valid"));
            yield return new TestCaseData(getDataParser().extractData("username_wrong"), getDataParser().extractData("password_wrong"));

        }

        [Test, Category("Smoke")]
        [TestCase("autouser1@maildrop.cc", "Welcome1")]
        public void ValidLogin(string user, string pass)
        {
            string username_valid = "autouser1@maildrop.cc"; 
            LoginPage loginPage = new LoginPage(getDriver());
            ProductsPage productsPage = loginPage.ValidLogin(user, pass);
            productsPage.WaitForLogoutDisplay();
            string userLogin = productsPage.getuserLogin().Text;
            TestContext.Progress.WriteLine(userLogin);
            Assert.AreEqual(username_valid, userLogin);
        }


    }
}
