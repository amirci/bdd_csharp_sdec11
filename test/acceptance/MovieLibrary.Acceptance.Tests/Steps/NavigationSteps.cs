using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace MovieLibrary.Acceptance.Tests.Steps
{
    /// <summary>
    /// Steps that define navigation between pages
    /// </summary>
    [Binding]
    public class NavigationSteps : BaseSteps
    {
        /// <summary>
        /// Goes to the specified page
        /// </summary>
        /// <param name="pageName">Page name to got to</param>
        [When(@"I go to ""(.*)""")]
        [Given(@"I'm on the ""(.*)"" page")]
        public void GoToPage(string pageName)
        {
            Browser.GoTo(PathFor(pageName));
        }

        /// <summary>
        /// Finds the link on the page and follows
        /// </summary>
        /// <param name="linkText">Link to find</param>
        [When(@"I follow ""(.*)""")]
        public void FollowLink(string linkText)
        {
            var found = Browser.Instance.Link(link => link.InnerHtml.Trim().Equals(linkText));

            found.Click();
        }

        /// <summary>
        /// Gets the path for the page name
        /// </summary>
        /// <param name="pageName">Page name to look for</param>
        /// <returns>The path if found or the same value if not</returns>
        private static string PathFor(string pageName)
        {
            var dictionary = new Dictionary<string, string>
                                {
                                    { "home", "" },
                                    { "add", "Movies/Create" }
                                };

            string result;

            dictionary.TryGetValue(pageName.ToLower(), out result);

            return result ?? pageName;
        }
    }
}
