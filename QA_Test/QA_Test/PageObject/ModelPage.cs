using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace QA_Test.PageObject
{
    public class ModelPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Ноутбук Lenovo ThinkPad X1 Carbon Gen 8 (20U90006RT)')]/ancestor::*//span[@class='result__tools']//span[@data-name='Ноутбук Lenovo ThinkPad X1 Carbon Gen 8 (20U90006RT)']")]
        private IWebElement ProductPrice;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Ноутбук Lenovo ThinkPad X1 Carbon Gen 8 (20U90006RT)')]/parent::a/parent::dt//span[@class='result__tools']//button[contains(text(), 'В корзину')]")]
        private IWebElement ProductBasket;
        [FindsBy(How = How.ClassName, Using = "private_tools__item")]
        private IWebElement Basket;
        public double price;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Ноутбук Lenovo ThinkPad X1 Carbon Gen 8 (20U90006RT)')]/ancestor::dl//dt//span[@class='item__notification']//a[contains(text(), 'Узнать о поступлении')]")]
        private IWebElement WaitList;
        public ModelPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }
        public void findAndClick(By by)
        {
            driver.FindElement(by).Click();
        }
        public void WaitElement(By by)
        {
            try
            {
                wait.Until(drv => drv.FindElement(by));
            }
            catch (NoSuchElementException) { WaitElement(by); }
        }
        public void WaitPage()
        {
            wait.Until(drv => drv.PageSource);
        }

        public void CheckPrice()
        {
            price = Convert.ToDouble(ProductPrice.Text);
        }
        public void Ordered()
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 4000)");
                if (ProductBasket.Displayed)
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    CheckPrice();
                    ProductBasket.Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    Basket.Click();
                }
                else
                    if (WaitList.Displayed)
                {
                    WaitList.Click();
                    WaitingListPage waitingListPage = new WaitingListPage(driver);
                    waitingListPage.WaitingList();
                }
            }
            catch (WebDriverException) { Ordered(); }
        }
    }
}
