using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace QA_Test.PageObject
{
    public class MainPage
    {
        private IWebDriver driver;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Компьютеры')]")]
        private IWebElement compBtn;
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Ноутбуки')]")]
        private IWebElement lapBtn;
        public MainPage(IWebDriver driver) { this.driver = driver; PageFactory.InitElements(driver, this); }
        public void goToMainPage()
        {
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.21vek.by/";
        }
        public LaptopPage goToLaptopPage()
        {
            compBtn.Click();
            lapBtn.Click();
            return new LaptopPage(driver);
        }
    }
}
