using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace QA_Test.PageObject
{
    public class OrderPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        [FindsBy(How = How.XPath, Using = "//span[@class='j-basket__cost']")]
        private IWebElement Price;
        [FindsBy(How = How.XPath, Using = "//button[@id='j-basket__ok']")]
        private IWebElement buttonOk;
        [FindsBy(How = How.XPath, Using = "//button[@id='j-basket__confirm']")]
        private IWebElement buttonConfirm;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Это поле обязательно для заполнения')]")]
        private IWebElement Warning;
        public OrderPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            PageFactory.InitElements(driver, this);
        }
        public void WaitPage()
        {
            wait.Until(drv => drv.PageSource);
        }
        public void CheckPrice(double price)
        {
            try
            {
                double basketPrice = Convert.ToDouble(Price.Text.Replace(" ", string.Empty).Replace("р.", string.Empty));
                Assert.IsTrue(price == basketPrice);
            }
            catch (NoSuchElementException) { RegistrationProduct(price); }
        }
        public void RegistrationProduct(double price)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            WaitPage();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            CheckPrice(price);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            buttonOk.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            buttonConfirm.Click();
            Assert.IsTrue(Warning.Displayed);
            driver.Quit();
        }
    }
}
