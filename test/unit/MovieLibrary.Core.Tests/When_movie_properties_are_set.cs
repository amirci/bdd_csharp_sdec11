using System;
using Rhino.Mocks;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MovieLibrary.Core.Tests
{
    /// <summary>
    /// Specification when setting the movie title
    /// </summary>
    [ConstructorSpecification]
    public class When_movie_properties_are_set : MovieSpecification
    {
        private string _expectedTitle;
        private DateTime _expectedReleaseDate;

        protected override IMovie CreateSut()
        {
            return new Movie
                       {
                           Title = this._expectedTitle,
                           ReleaseDate = this._expectedReleaseDate
                       };
        }

        protected override void GivenThat()
        {
            base.GivenThat();

            this._expectedTitle = "Blazing Saddles";
            this._expectedReleaseDate = new DateTime(1972, 12, 01);
        }

        /// <summary>
        /// Checks that the title is set
        /// </summary>
        [It]
        public void Should_have_the_expected_title()
        {
            this.Sut.Title.Should().Be(this._expectedTitle);
        }

        /// <summary>
        /// Checks that release date is set
        /// </summary>
        [It]
        public void Should_have_the_expected_release_date()
        {
            this.Sut.ReleaseDate.Should().Be(this._expectedReleaseDate);
        }
    }
}