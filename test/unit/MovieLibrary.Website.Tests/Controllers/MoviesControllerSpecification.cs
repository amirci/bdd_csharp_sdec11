using System.Web.Mvc;
using MavenThought.Commons.Testing;
using MovieLibrary.Core;
using MovieLibrary.Website.Controllers;

namespace MovieLibrary.Website.Tests.Controllers
{
    /// <summary>
    /// Base specification for MoviesController
    /// </summary>
    public abstract class MoviesControllerSpecification
        : AutoMockSpecificationWithNoContract<MoviesController>
    {
        protected ActionResult Result { get; set; }

        protected override MoviesController CreateSut()
        {
            return new MoviesController(Dep<IMovieLibrary>());
        }
    }
}