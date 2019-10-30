using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;
using dotNetAutomationgoogleTest.Controllers;
using dotNetAutomationgoogleTest.Pages.Google;
using SeleniumExtras.PageObjects;

namespace dotNetAutomationgoogleTest.BusinessController
{
    class Business
    {
        private static NUnit.Framework.Internal.Logger _logger;

        public NUnit.Framework.Internal.Logger Logger
        {
            get => _logger;
            set => _logger = value;
        }

        private Home googleHome;
        private Results googleResults;
        private string evidencePath;
        private static WebActions webActions;

        public Business(string path, string feature, string scenario)
        {
            webActions = new WebActions(path, feature, scenario);
            evidencePath = webActions.getEvidencePath();
        }

        public string GetEvidencePath()
        {
            return evidencePath;
        }

        public void GoToGoogleHome()
        {
            string operation = "Go to google home page";

            try
            {
                _logger.Info((string)"+Operation= ".Concat(operation));
                webActions.launchWebApp("Chrome", "http://www.google.com");
                PageFactory.InitElements(webActions.Driver, googleHome);
                bool esGoogle = googleHome.CheckPage();
                Assert.IsTrue(esGoogle);
                _logger.Warning("The operation has finished successfully");
            }
            catch (Exception e)
            {
                Assert.Fail("The operation has failed: "
                    , e.Message);
                throw;
            }
        }

        public void CloseBrowser()
        {
            try
            {
                webActions.closeWebApp();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        public void TypeInGoogleSearchField(string searchString, bool closeSearchList)
        {
            string operation = "Type in the google search field";
            try
            {
                _logger.Info("----------Operation: ", operation, "----------");

                googleHome.TypeSearch(searchString);
                if (closeSearchList) googleHome.CloseSearchList();

                _logger.Info("The operation has finished successfully\n");
            }
            catch (Exception)
            {
                Assert.Fail("Operation failed");
            }
        }

        public void ClickOnGoogleSearchButton()
        {
            string operation = "Click on the google search button";
            try
            {
                _logger.Info((string)"-Operation: ".Concat(operation));

                googleHome.PressSearchButton();

                _logger.Info("The operation has finished successfully\n");
            }
            catch (Exception)
            {
                _logger.Error("Operation failed");
                Assert.Fail();
            }
        }

        public void CheckGoogleResultsPage()
        {
            string operation = "Check the google results page";
            try
            {
                _logger.Info((string)"-Operation: ".Concat(operation));

                PageFactory.InitElements(webActions.Driver, googleResults);
                bool esGoogleResultPage = googleResults.checkPage();
                Assert.IsTrue(esGoogleResultPage);

                _logger.Info("The operation has finished successfully\n");
            }
            catch (Exception)
            {
                _logger.Error("Operation failed");
                Assert.Fail();
            }
        }

        public void CheckSpecificSearchResult(string resultExpected, int position)
        {
            string operation = "Check the first google result";
            try
            {
                _logger.Info((string)"-Operation: ".Concat(operation));

                string resultObtained = googleResults.getResult(position);
                Assert.Equals(resultObtained, resultExpected);
                _logger.Info("Result was ", resultObtained
                    .Concat(" but the expected one is")
                    .Concat(resultExpected));

                _logger.Info("The operation has finished successfully\n");
            }
            catch (Exception)
            {
                _logger.Error("Operation failed");
                Assert.Fail();
            }
        }

        public void CheckSuggestionListIsDisplayed()
        {
            string operation = "Check that the suggestion list is displayed";
            try
            {
                _logger.Info((string)"-Operation: ".Concat(operation));

                bool isSuggestionListVisible = googleHome.IsSuggestionListVisible();
                Assert.IsTrue(isSuggestionListVisible);

                _logger.Info("The operation has finished successfully\n");
            }
            catch (Exception)
            {
                _logger.Error("Operation failed");
                Assert.Fail();
            }
        }

        public void ClickOnSpecificSearchResult(int position)
        {
            string operation = "Click on the first search result";
            try
            {
                _logger.Info((string)"-Operation: ".Concat(operation));

                googleResults.clickFirstResult(position);

                _logger.Info("The operation has finished successfully\n");
            }
            catch (Exception)
            {
                _logger.Error("Operation failed");
                Assert.Fail();
            }
        }

        public void CompareTabUrl(string urlExpected)
        {
            string operation = "Compare current url with the expected";
            try
            {
                _logger.Info((string)"-Operation: ".Concat(operation));

                WebActions.takeScreenShot();
                string obtainedURL = webActions.getTabURL();
                Assert.Equals(urlExpected, obtainedURL);

                _logger.Info("Result was ", obtainedURL
                    .Concat(" but the expected one is")
                    .Concat(urlExpected));

                _logger.Info("The operation has finished successfully\n");
            }
            catch (Exception)
            {
                _logger.Error("Operation failed");
                Assert.Fail();
            }
        }

        public void ClickOnSpecificElementFromSuggestionList(int elementPosition)
        {
            string operation = "Click on specific element of the suggestion list";
            try
            {
                _logger.Info((string)"-Operation: ".Concat(operation));

                int suggestedOptions = googleHome.GetSuggestedOptionsQty();
                if (suggestedOptions < elementPosition + 1) throw new Exception("The list only have".Concat(string.Format(suggestedOptions.ToString())).Concat("elements") as string);
                googleHome.ClickOnelementFromSuggestionList(elementPosition);

                _logger.Info("The operation has finished successfully\n");
            }
            catch (Exception)
            {
                _logger.Error("Operation failed");
                Assert.Fail();
            }
        }
    }
}
