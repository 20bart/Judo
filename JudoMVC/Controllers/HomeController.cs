using System.Data.Entity;
using System.Web.Mvc;
using JudoModelsLibrary;
using JudoMVC.Helper;
using MyResources.Home;

namespace JudoMVC.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<JudoContext>());
            //System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<JudoContext>());

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = Resource.YourAppDescPageText;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = Resource.YourContactPageText;

            return View();
        }

        public ActionResult SetCulture(string culture, string returnUrl)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);

            Session["_culture"] = culture;

            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}