using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace QA_Test1.PageObject
{
    public class CheckWaitListPage
    {
        private IWebDriver driver;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Вертикальный портативный пылесос National NH-VS1413')]/ancestor::dl/dd//span[@class='item__notification']//span")]
        private IWebElement Info;
        public CheckWaitListPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Checking()
        {
            var WaitingList = Info.Text;
            Assert.AreEqual(WaitingList, "В листе ожидания");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Quit();
        }
    }
}
