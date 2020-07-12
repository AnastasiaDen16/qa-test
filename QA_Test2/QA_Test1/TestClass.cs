using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA_Test1.PageObject;
using SeleniumExtras.PageObjects;

namespace QA_Test1
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Perfomance()
        {
            MainPage home = new MainPage(driver);
            home.goToMainPage();
            SearchPage searchPage = home.Searching();
            searchPage.SearchProduct();
        }
    }
}