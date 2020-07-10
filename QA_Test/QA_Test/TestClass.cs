using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA_Test.PageObject;

namespace QA_Test
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(@"E:\Work\QA_Test");
        }

        [Test]
        public void SearchTextFromAboutPage()
        {
            MainPage home = new MainPage(driver);
            home.goToMainPage();
            LaptopPage lapPage = home.goToLaptopPage();
            ModelPage model = lapPage.EnterValue();
            model.Ordered();
            OrderPage order = new OrderPage(driver);
            order.RegistrationProduct(model.price);
        }
    }
}