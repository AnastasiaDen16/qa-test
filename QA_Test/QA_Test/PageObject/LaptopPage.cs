using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace QA_Test.PageObject
{
    public class LaptopPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        [FindsBy(How = How.Name, Using = "filter[price][from]")]
        private IWebElement priceFrom;
        [FindsBy(How = How.Name, Using = "filter[price][to]")]
        private IWebElement priceTo;
        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'В наличии')]")]
        private IWebElement Presence;
        [FindsBy(How = How.XPath, Using = "//label[@title='Lenovo']")]
        private IWebElement Model;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Линейка')]")]
        private IWebElement Line;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Модель процессора')]")]
        private IWebElement scrollFor;
        [FindsBy(How = How.XPath, Using = "//*[@id='j-filter__form']/div[4]/dl[1]/dd/span[contains(text(), 'Показать всё')]")]
        private IWebElement ShowAll;
        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'IdeaPad L (Lenovo)')]")]
        private IWebElement ModelFirst;
        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Legion (Lenovo)')]")]
        private IWebElement ModelSecond;
        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Lenovo ThinkPad X')]")]
        private IWebElement ModelThird;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Тип')]")]
        private IWebElement Type;
        [FindsBy(How = How.XPath, Using = "//label[@title='ультрабук']")]
        private IWebElement typeModel;
        [FindsBy(How = How.Id, Using = "j-filter__btn")]
        private IWebElement OpenAll;
        public LaptopPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(driver, this);
        }
        public void WaitPage()
        {
            wait.Until(drv => drv.PageSource);
        }

        public void EnterPrice()
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            try
            {
                WaitPage();
                priceFrom.Click();
                priceFrom.SendKeys("1200");
                priceTo.SendKeys("6840");
            }
            catch (NoSuchElementException) { EnterPrice(); }
        }
        public ModelPage EnterValue()
        {
            EnterPrice();
            Presence.Click();
            Model.Click();
            Line.Click(); 
            Actions actions = new Actions(driver);
            actions.MoveToElement(scrollFor);
            actions.Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            ShowAll.Click();
            ModelFirst.Click();
            ModelSecond.Click();
            ModelThird.Click();
            Type.Click();
            typeModel.Click();
            OpenAll.Click();
            return new ModelPage(driver);
        }
    }
}
