using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace QA_Test.PageObject
{
    public class WaitingListPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        [FindsBy(How = How.XPath, Using = "//button[@class='g-button j-submit']")]
        private IWebElement waitListBtn;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Это поле обязательно для заполнения')]")]
        private IWebElement textImportant;
        [FindsBy(How = How.Name, Using = "data[name]")]
        private IWebElement UserName;
        [FindsBy(How = How.Name, Using = "data[email]")]
        private IWebElement UserEmail;
        [FindsBy(How = How.XPath, Using = "//button[@class='g-button j-submit']")]
        private IWebElement okBtn;
        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Если товар появится на складе, вам придет сообщение на почту.')]")]
        private IWebElement AboutList;
        [FindsBy(How = How.XPath, Using = "//button[@class='g-button j-popup__close']")]
        private IWebElement CloseBtn;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Ноутбук Lenovo ThinkPad X1 Carbon Gen 8 (20U90006RT)')]/ancestor::dl//dt//span[@class='item__notification']//span[contains(text(), 'В листе ожидания')]")]
        private IWebElement Info;
        public WaitingListPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(driver, this);
        }
        public void Checking()
        {
            var WaitingList = Info.Text;
            Assert.AreEqual(WaitingList, "В листе ожидания");
            driver.Quit();
        }
        public void WaitingList()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            waitListBtn.Click(); ;
            Assert.IsTrue(textImportant.Displayed);
            UserName.SendKeys("Тест");
            Random rand = new Random();
            int randMail = rand.Next(0, 500);
            string email = "test" + randMail.ToString() + "@mail.ru";
            UserEmail.SendKeys(email);
            okBtn.Click(); ;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Assert.IsTrue(AboutList.Displayed);
            CloseBtn.Click(); ;
            Checking();
        }
    }
}
