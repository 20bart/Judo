using System;
using System.Collections.Generic;
using System.Web.Mvc;
using JudoModelsLibrary;
using JudoMVC.Models;
using JudoMVC.Services;
using JudoServiceLibrary;

namespace JudoMVC.Controllers
{
    [Authorize]
    public class InschrijvingenController : BaseController
    {
        // GET: Inschrijvingen
        public ActionResult Index()
        {
            return View();
        }

        //
        //GET: Inschrijvingen/SelectTornooi
        public ActionResult SelectTornooi()
        {
            var tornooiService = new TornooiService();
            var tornooien = tornooiService.GetTornooienNaDatum(DateTime.Now);
            return View(tornooien);
        }

        //
        //GET: Inschrijvingen/SelectDeelnemers
        public ActionResult SelectDeelnemers(int tornooiId)
        {
            //Get Tornooi
            var tornooiService = new TornooiService();
            var tornooi = tornooiService.ReadWithGemeenteAndLandAndLeeftijdCategories(tornooiId);
            Session["tornooi"] = tornooi;

            //Get Current club
            var userService = new UserService();
            var club = userService.GetCurrentClub();

            //Get Deelnemers
            var deelnemersService = new DeelnemerService();
            var deelnemersChecked = new List<DeelnemerCheckedViewModel>();

            foreach (var categorie in tornooi.TornooiLeeftijdCategories)
            {
                var jongsteJaar = DateTime.Now.Year - categorie.LeeftijdCategorie.LeeftijdBegin;
                var oudsteJaar = DateTime.Now.Year - categorie.LeeftijdCategorie.LeeftijdEinde;
                var deelnemers = deelnemersService.GetDeelnemersFromClubBetweenYears(club.ClubId, jongsteJaar, oudsteJaar);
                foreach (var deelnemer in deelnemers)
                {
                    deelnemersChecked.Add(new DeelnemerCheckedViewModel()
                    {
                        DeelnemerId = deelnemer.DeelnemersId,
                        Voornaam = deelnemer.Voornaam,
                        Familienaam = deelnemer.Familienaam,
                        Geslacht = deelnemer.Geslacht,
                        GeboorteJaar = deelnemer.GeboorteJaar,
                        Assigned = false
                    });
                }
            }
            
            return View(deelnemersChecked);
        }

        //
        //POST: Inschrijvingen/SelectDeelnemers
        [HttpPost]
        public ActionResult SelectDeelnemers(List<DeelnemerCheckedViewModel> deelnemersChecked)
        {
            List<Deelnemer> deelnemers = new List<Deelnemer>();
            var deelnemerService = new DeelnemerService();
            foreach (var deelnemer in deelnemersChecked)
            {
                if(deelnemer.Assigned)
                    deelnemers.Add(deelnemerService.Read(deelnemer.DeelnemerId));
            }
            TempData["deelnemers"] = deelnemers;
            return RedirectToAction("Bevestigen");
        }

        //
        //GET: Inschrijvingen/Bevestigen
        public ActionResult Bevestigen()
        {
            //Get deelnemers
            var deelnemer = (List<Deelnemer>)TempData["deelnemers"];

            //Get Current club
            var userService = new UserService();
            var club = userService.GetCurrentClub();
            ViewBag.Club = club;

            //Get Current Verantwoordelijke
            var verantw = userService.GetCurrentVerantwoordelijke();
            ViewBag.Verantwoordelijke = verantw;

            return View(deelnemer);
        }

        //
        //POST: Inschrijvingen/Bevestigen
        [HttpPost]
        public ActionResult Bevestigen(List<Deelnemer> deelnemers)
        {
            //Email naar verantwoordelijke en naar club
            //Delete session tornooi
            throw new NotImplementedException();
        }
        
    }
}