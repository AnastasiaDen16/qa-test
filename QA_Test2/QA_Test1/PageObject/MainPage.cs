using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA_Test1.PageObject
{
    public class MainPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "search__submit")]
        private IWebElement searchBtn;

        [FindsBy(How = How.Id, Using = "j-search")]
        private IWebElement search;

        public MainPage(IWebDriver driver) 
        { 
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void goToMainPage()
        {
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.21vek.by/";
        }
        public SearchPage Searching()
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            search.SendKeys("National");
            searchBtn.Click() ;
            return new SearchPage(driver);
        }
    }
}
