using MavenThought.Commons.Testing;
using MvcContrib.TestHelper;

namespace MovieLibrary.Website.Tests.Controllers
{
    /// <summary>
    /// Specification when ...
    /// </summary>
    [Specification]
    public class When_movies_controller_calls_index : MoviesControllerSpecification
    {
        protected override void WhenIRun()
        {
            this.Result = this.Sut.Index();
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