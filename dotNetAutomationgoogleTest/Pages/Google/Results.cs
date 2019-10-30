using dotNetAutomationgoogleTest.Controllers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetAutomationgoogleTest.Pages.Google
{
    class Results
    {
        private IWebDriver _driver;


        public Results(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='search']//h3")]
        private List<IWebElement> lnkResults;

        [FindsBy(How = How.XPath, Using = "//div[@id='hdtb-msb-vis']/div[@aria-selected='true']")]
        private IWebElement opcAllResults;

        [FindsBy(How = How.XPath, Using = "//div[@id='hdtb-msb-vis']/div[@aria-selected='true']")]
        private By opcAllResults2;

        public bool checkPage()
        {
            return WebActions.isVisible(opcAllResults2, "all results option", new TimeSpan(0, 0, 30), true);
        }

        public string getResult(int position)
        {
            return WebActions.getTextFromElement(lnkResults.ElementAt(position), " search result", false);
        }

        public void clickFirstResult(int position)
        {
            WebActions.clickElement(lnkResults.ElementAt(position), " search result", false);
        }
    }
}
