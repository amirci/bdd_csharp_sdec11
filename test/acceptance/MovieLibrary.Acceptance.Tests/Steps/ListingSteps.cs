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

        /// <summary>
        /// Checks the movie is in the listing
        /// </summary>
        /// <param name="movies">Movies to look for</param>
        [Then(@"I should see in the listing:")]
        public void AssertListingContains(Table movies)
        {
            var expected = movies.Rows.Select(row => row["title"]);

            this.Listing.Should().Have.SameSequenceAs(expected);
        }

        /// <summary>
        /// Checks the movie is in the listing
        /// </summary>
        /// <param name="title">Title to check for</param>
        [Then(@"I should see ""(.*)"" in the listing")]
        public void AssertListingContains(string title)
        {
            this.Listing.Should().Contain(title);
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


