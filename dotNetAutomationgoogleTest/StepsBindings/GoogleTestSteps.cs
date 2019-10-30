using System;
using TechTalk.SpecFlow;
using dotNetAutomationgoogleTest.BusinessController;

namespace dotNetAutomationgoogleTest.StepsBindings
{
    [Binding, Scope(Tag = "TechTest")]
    public class GoogleTestSteps
    {
        Business businessController;

        [Given(@"I’m on the homepage")]
        public void GivenIMOnTheHomepage()
        {
            businessController.GoToGoogleHome();
        }

        [When(@"I type '(.*)' into the search field")]
        public void WhenITypeIntoTheSearchField(string p0)
        {
            businessController.TypeInGoogleSearchField("The name of the wind", true);
        }

        [When(@"I click the Google Search button")]
        public void WhenIClickTheGoogleSearchButton()
        {
            businessController.ClickOnGoogleSearchButton();
        }

        [When(@"the suggestions list is displayed")]
        public void WhenTheSuggestionsListIsDisplayed()
        {
            businessController.CheckSuggestionListIsDisplayed();
        }

        [When(@"I click on the first suggestion in the list")]
        public void WhenIClickOnTheFirstSuggestionInTheList()
        {
            businessController.ClickOnSpecificElementFromSuggestionList(0);
        }

        [When(@"I click on the first result link")]
        public void WhenIClickOnTheFirstResultLink()
        {
            businessController.ClickOnSpecificSearchResult(0);
        }

        [Then(@"I go to the search results page")]
        public void ThenIGoToTheSearchResultsPage()
        {
            businessController.CheckGoogleResultsPage();
        }

        [Then(@"the first result is '(.*)'")]
        public void ThenTheFirstResultIs(string p0)
        {
            businessController.CheckSpecificSearchResult("The Name of the Wind - Patrick Rothfuss", 0);
        }

        [Then(@"I go to the '(.*)' page")]
        public void ThenIGoToThePage(string p0)
        {
            businessController.CompareTabUrl("https://www.patrickrothfuss.com/content/books.asp");
        }
    }
}
