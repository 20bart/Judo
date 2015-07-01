using System.Web.Mvc;
using JudoModelsLibrary;
using JudoMVC.Services;
using JudoServiceLibrary;

namespace JudoMVC.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        //
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: User/ChangeUser
        public ActionResult ChangeUser()
        {
            var userService = new UserService();
            return View(userService.GetCurrentVerantwoordelijke());
        }

        //
        // POST: USER/ChangeUser
        [HttpPost]
        public ActionResult ChangeUser(Verantwoordelijke model)
        {
            if (ModelState.IsValid)
            {
                //Get current verantwoordelijke
                var userService = new UserService();
                var verantw = userService.GetCurrentVerantwoordelijke();

                //Get email from currentUser
                model.Email = verantw.Email;

                //If something changed -> save
                if (model.Voornaam != verantw.Voornaam || model.Familienaam != verantw.Familienaam || model.Telefoonnummer != verantw.Telefoonnummer)
                {
                    //Update verantwoordelijke
                    var verantwService = new VerantwoordelijkeService();
                    ViewBag.ChangesSaved = verantwService.Update(verantw.VerantwoordelijkeId, model.Voornaam, model.Familienaam, model.Email, model.Telefoonnummer);
                }
                else
                {
                    ViewBag.NothingChanged = true;
                }
            }
            return View(model);
        }

        //
        // GET: User/ChangeClub
        public ActionResult ChangeClub()
        {
            //Get current club
            var userService = new UserService();
            
            //Fill landen for dropdown
            var landService = new LandService();
            var landen = landService.FindAll();
            ViewBag.Landen = landen;

            return View(userService.GetCurrentClub());
        }

        //
        // POST: User/ChangeClub
        [HttpPost]
        public ActionResult ChangeClub(Club model)
        {
            if (ModelState.IsValid)
            {
                //Get current club
                var userService = new UserService();
                var club = userService.GetCurrentClub();
                
                //If something changed -> save
                if (club.ClubNummer != model.ClubNummer || club.Naam != model.Naam || club.Adres != model.Adres || club.Huisnummer != model.Huisnummer || club.Gemeente.Postcode != model.Gemeente.Postcode || club.Gemeente.Plaats != model.Gemeente.Plaats || club.Gemeente.Land.LandId != model.Gemeente.Land.LandId || club.Gemeente.Land.LandNaam != model.Gemeente.Land.LandNaam)
                {
                    var clubService = new ClubService();
                    ViewBag.ChangesSaved = clubService.Update(club.ClubId, model.ClubNummer, model.Naam, model.Adres, model.Huisnummer, model.Gemeente.Postcode, model.Gemeente.Plaats, model.Gemeente.Land.LandId, model.Gemeente.Land.LandNaam);
                    //to set landid correct
                    model = clubService.ReadWithGemeenteAndLand(club.ClubId);
                }
                else
                {
                    ViewBag.NothingChanged = true;
                }
            }

            //Fill landen for dropdown
            var lService = new LandService();
            var landen = lService.FindAll();
            ViewBag.Landen = landen;

            return View(model);
        }
    }
}