using System.Web.Mvc;

namespace GenericRepositoryUoW.Web.Controllers
{
    /// <summary>
    /// Controllers are responsible to prepare Model which will be mapped to a view.
    /// HomeController is default home views controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Home/Index views corresponding action
        /// </summary>
        /// <returns>Returns the view corresponding to the action method which is Home/Index</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Home/About views corresponding action
        /// </summary>
        /// <returns>Returns the view corresponding to the action method which is Home/About</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Home/Contact views corresponding action
        /// </summary>
        /// <returns>Returns the view corresponding to the action method which is Home/Contact</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}