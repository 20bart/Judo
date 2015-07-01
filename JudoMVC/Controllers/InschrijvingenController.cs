using System;
using System.Collections.Generic;
using System.Web.Mvc;
using JudoMVC.Models;
using JudoMVC.Services;
using JudoServiceLibrary;

namespace JudoMVC.Controllers
{
    [Authorize]
    public class InschrijvingenController : Controller
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
            ViewBag.Tornooi = tornooi;

            //Get Current club
            var userService = new UserService();
            var club = userService.GetCurrentClub();

            //Get Deelnemers
            var deelnemersService = new DeelnemerService();
            var deelnemers = deelnemersService.GetDeelnemersFromClub(club.ClubId);

            var deelnemersChecked = new List<DeelnemerCheckedViewModel>();
            foreach (var deelnemer in deelnemers)
            {
                deelnemersChecked.Add(new DeelnemerCheckedViewModel()
                {
                    DeelnemerId = deelnemer.DeelnemersId,
                    Voornaam =  deelnemer.Voornaam,
                    Familienaam = deelnemer.Familienaam,
                    Geslacht = deelnemer.Geslacht,
                    GeboorteJaar = deelnemer.GeboorteJaar,
                    Assigned = false
                });
            }

            return View(deelnemersChecked);
        }
    }
}