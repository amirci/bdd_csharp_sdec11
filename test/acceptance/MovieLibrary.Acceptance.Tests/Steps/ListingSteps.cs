using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace MovieLibrary.Acceptance.Tests.Steps
{
    /// <summary>
    /// Steps to implement browse movie feature
    /// </summary>
    [Binding]
    public class ListingSteps : BaseSteps
    {
        protected IEnumerable<string> Listing
        {
            get
            {
                return Browser
                    .Instance
                    .TableCells
                    .Where(cell => cell.ClassName == "title")
                    .Select(cell => cell.InnerHtml.Trim());
            }
        }
        
        [Then(@"I should see all the movies listed in the page")]
        public void ShouldSeeAllMovies()
        {
            this.Listing.Should().Have.SameSequenceAs(LibrarySteps.Titles);
        }

        /// <summary>
        /// Checks no movies are shown
        /// </summary>
        [Then(@"I should see the message ""(.*)""")]
        public void AssertPageContains(string message)
        {
            this.Browser.Instance
                .FindText(new Regex(message))
                .Should().Not.Be.Null();
        }
    }
}


