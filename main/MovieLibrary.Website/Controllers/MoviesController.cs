using System.Web.Mvc;
using MovieLibrary.Core;

namespace MovieLibrary.Website.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieLibrary _movieLibrary;

        public MoviesController(IMovieLibrary movieLibrary)
        {
            _movieLibrary = movieLibrary;
        }

        /// <summary>
        /// Lists the contents of the library
        /// </summary>
        /// <returns>An action result with a collection of movies as model</returns>
        public ActionResult Index()
        {
            return View(this._movieLibrary.Contents);
        }
    }
}