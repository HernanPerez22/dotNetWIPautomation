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
    class Home
    {
        private IWebDriver _driver;

        public Home(IWebDriver driver, List<IWebElement> ulSearchSuggestionElements)
        {
            _driver = driver;
            this.ulSearchSuggestionElements = ulSearchSuggestionElements;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "q")] private IWebElement inputSearchField;

        [FindsBy(How = How.XPath, Using = "//input[@name='q']//parent::div")]
        private IWebElement txtSearchField;

        [FindsBy(How = How.XPath, Using = "//div[@class='FPdoLc VlcLAe']//input[@name='btnK']")]
        private IWebElement btnGoogleSearch;

        [FindsBy(How = How.XPath, Using = "//div[@class='FPdoLc VlcLAe']//input[@name='btnK']")]
        private By btnGoogleSearch2;

        [FindsBy(How = How.XPath, Using = "//div[@class='FPdoLc VlcLAe']//input[@name='btnI']")]
        private IWebElement btnImFeelingLucky;

        [FindsBy(How = How.XPath, Using = "//img[@alt='Google']")]
        private IWebElement imgGoogle;

        [FindsBy(How = How.XPath, Using = "//ul[@role='listbox']")]
        private By ulSuggestionList;

        [FindsBy(How = How.XPath, Using = "//ul[@role='listbox']/li")]
        private List<IWebElement> ulSearchSuggestionElements;


        public void TypeSearch(string textToSearch)
        {
            WebActions.sendTextToElement(inputSearchField, "google search field", textToSearch, false);
        }

        public void CloseSearchList()
        {
            WebActions.waitVisible(ulSuggestionList, "suggestion list", new TimeSpan(0, 0, 30), true);
            WebActions.clickElement(imgGoogle, "google logo", false);
        }

        public bool IsSuggestionListVisible()
        {
            return WebActions.isVisible(ulSuggestionList, "suggestion list", new TimeSpan(0, 0, 30), true);
        }

        public void PressSearchButton()
        {
            WebActions.clickElement(btnGoogleSearch, "google search button", false);
        }

        public bool CheckPage()
        {
            return WebActions.isVisible(btnGoogleSearch2, "google search button", new TimeSpan(0, 0, 30), true);
        }

        public int GetSuggestedOptionsQty()
        {
            return ulSearchSuggestionElements.Count;
        }

        public void ClickOnelementFromSuggestionList(int elementPosition)
        {
            WebActions.clickElement(ulSearchSuggestionElements.ElementAt(elementPosition), "element '"
                .Concat(string.Format((elementPosition + 1).ToString()))
                .Concat("' from suggestion list").ToString(), false);
        }
    }
}
