using System.Web.Mvc;

namespace MovieLibrary.Website.Controllers
{
    public class MoviesController : Controller
    {
        /// <summary>
        /// Lists the contents of the library
        /// </summary>
        /// <returns>An action result with a collection of movies as model</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}