using System.Collections.Generic;
using System.Web.Mvc;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;
using MovieLibrary.Core;
using MvcContrib.TestHelper;
using Rhino.Mocks;
using SharpTestsEx;

namespace MovieLibrary.Website.Tests.Controllers
{
    /// <summary>
    /// Specification when calling the index method
    /// </summary>
    [Specification]
    public class When_movies_controller_calls_index : MoviesControllerSpecification
    {
        private IEnumerable<IMovie> _expected;

        protected override void GivenThat()
        {
            base.GivenThat();

            this._expected = 10.Times(() => Mock<IMovie>());

            Dep<IMovieLibrary>().Stub(lib => lib.Contents).Return(this._expected);
        }

        protected override void WhenIRun()
        {
            this.Result = this.Sut.Index();
        }

        /// <summary>
        /// Checks that index method returns all the movies
        /// </summary>
        [It]
        public void Should_return_all_movies_in_the_library()
        {
            var viewResult = (ViewResult) this.Result;

            var movies = (IEnumerable<IMovie>) viewResult.Model;

            movies.Should().Have.SameSequenceAs(this._expected);
        }

        /// <summary>
        /// Checks that the result is rendered
        /// </summary>
        [It]
        public void Should_render_the_index_view()
        {
            this.Result.AssertViewRendered();
        }
    }
}