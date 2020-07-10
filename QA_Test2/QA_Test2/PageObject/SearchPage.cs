using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA_Test1.PageObject
{
    public class SearchPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Вертикальный портативный пылесос National NH-VS1413')]/ancestor::dl/dd//span[@class='result__tools-item']//form//button")]
        private IWebElement BasketProduct;

        [FindsBy(How = How.ClassName, Using = "private_tools__item")]
        private IWebElement Basket;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Вертикальный портативный пылесос National NH-VS1413')]/ancestor::dl//dd//span[@class='item__notification']//a[contains(text(), 'Узнать о поступлении')]")]
        private IWebElement WaitList;

        public double price;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Вертикальный портативный пылесос National NH-VS1413')]/ancestor::dl/dt//span[@class=' g-price result__price cr-price__in']//span[1]")]
        private IWebElement Price;
        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(driver, this);
        }
        public void WaitPage()
        {
            wait.Until(drv => drv.PageSource);
        }
        public void CheckPrice()
        {
            price = Convert.ToDouble(Price.Text);
        }
        public void SearchProduct()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 2000)");
                if (WaitList.Displayed)
                {
                    WaitList.Click();
                    WaitingListPage waitingListPage = new WaitingListPage(driver);
                    CheckWaitListPage checkWLPage = waitingListPage.WaitingList();
                    checkWLPage.Checking();
                }
                else
                if (BasketProduct.Displayed)
                {
                    CheckPrice();
                    BasketProduct.Click();
                    Basket.Click();
                    OrderPage orderPage = new OrderPage(driver);
                    orderPage.RegistrationProduct(price);
                }
            }
            catch (WebDriverException) { SearchProduct(); }
        }
    }
}
