using System.Web.Mvc;
using JudoModelsLibrary;
using JudoMVC.Models;
using JudoServiceLibrary;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JudoMVC.Controllers
{
    [Authorize]
    public class DeelnemerController : BaseController
    {
        // GET: Deelnemer
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: Inschrijven/DeelnemersBeheren
        public ActionResult DeelnemersBeheren(int? id, string todo)
        {
            var model = new DeelnemerViewModel();
            //Get current user
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());

            //Get club by email from current user
            var clubService = new ClubService();
            var club = clubService.GetClubByEmailWithVerantwoordelijke(currentUser.Email);

            model.ClubId = club.ClubId;

            var deelnemerService = new DeelnemerService();

            if (id.HasValue)
            {
                switch (todo)
                {
                    case "edit":
                        //edit deelnemer
                        var deelnemer = deelnemerService.Read(id.Value);
                        model.DeelnemerId = deelnemer.DeelnemersId;
                        model.Familienaam = deelnemer.Familienaam;
                        model.Voornaam = deelnemer.Voornaam;
                        model.Geslacht = deelnemer.Geslacht;
                        model.GeboorteJaar = deelnemer.GeboorteJaar;
                        ViewBag.todo = "edit";
                        break;
                    case "delete":
                        //delete deelnemer
                        deelnemerService.Delete(id.Value);
                        ViewBag.todo = "delete";
                        break;
                }
            }

            //Fill list with deelnemers
            ViewBag.Deelnemers = deelnemerService.GetDeelnemersFromClub(club.ClubId);

            return View(model);
        }

        //
        // POST: Inschrijven/DeelnemersToevoegen
        [HttpPost]
        public ActionResult DeelnemersBeheren(DeelnemerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var deelnemerService = new DeelnemerService();

                if (model.DeelnemerId != 0)
                {
                    deelnemerService.Update(model.DeelnemerId, model.Familienaam, model.Voornaam, model.GeboorteJaar.GetValueOrDefault(), model.Geslacht);
                }
                else
                {
                    deelnemerService.Create(new Deelnemer { Voornaam = model.Voornaam, Familienaam = model.Familienaam, GeboorteJaar = model.GeboorteJaar.GetValueOrDefault(), Geslacht = model.Geslacht, ClubId = model.ClubId });
                }

                return RedirectToAction("DeelnemersBeheren");
            }
            return View(model);
        }
    }
}