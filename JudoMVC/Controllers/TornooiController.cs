using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using JudoModelsLibrary;
using JudoMVC.Models;
using JudoMVC.Services;
using JudoServiceLibrary;

namespace JudoMVC.Controllers
{
    [Authorize]
    public class TornooiController : BaseController
    {
        // GET: Tornooi
        public ActionResult Index(int? saved)
        {
            //Get current club
            var userService = new UserService();
            var club = userService.GetCurrentClub();

            //Get Tornooien from club
            var tornooiService = new TornooiService();
            ViewBag.Tornooien = tornooiService.GetTornooiByClub(club.ClubId);

            if (saved != null)
                ViewBag.Saved = saved;
            return View();
        }

        //
        //GET: Tornooi/Toevoegen
        public ActionResult Toevoegen()
        {
            //Fill landen for dropdown
            var landService = new LandService();
            var landen = landService.FindAll();
            ViewBag.Landen = landen;
            var tornooiViewModel = new TornooiViewModel(){ AssignedLeeftijdCategories = PopulateLeeftijdsCategoriesData(), Datum = DateTime.Now, UitersteInschrijvingVoorAantalDagen = 7};
            return View(tornooiViewModel);
        }

        private static ICollection<AssignedCategoriesViewModel> PopulateLeeftijdsCategoriesData()
        {
            var leeftijdCategoriesService = new  LeeftijdCategorieService();
            var leeftijdcategories = leeftijdCategoriesService.FindAll();
            var assignedLeeftijdCategories = new List<AssignedCategoriesViewModel>();

            foreach (var item in leeftijdcategories)
            {
                assignedLeeftijdCategories.Add(new AssignedCategoriesViewModel
                {
                    LeeftijdCategorieId = item.LeeftijdCategorieId,
                    LeeftijdCategorieNaam = item.LeeftijdCategorieNaam,
                    Assigned = false
                });
            }
            return assignedLeeftijdCategories;
        }

        //
        //POST: Tornooi/Toevoegen
        [HttpPost]
        public ActionResult Toevoegen(TornooiViewModel tornooiViewModel)
        {
            var landService = new LandService();
            if (ModelState.IsValid)
            {
                var nieuwTornooi = new Tornooi();
                Land land;
                var gemeente = new Gemeente();
                if (tornooiViewModel.Gemeente.Land.LandId == -99)
                {
                    land = landService.GetLandByName(tornooiViewModel.Gemeente.Land.LandNaam);
                    if (land == null)
                    {
                        land = new Land { LandNaam = tornooiViewModel.Gemeente.Land.LandNaam };
                        gemeente.Land = land;
                    }
                    else
                        gemeente.LandId = land.LandId;
                }
                else
                {
                    land = landService.Read(tornooiViewModel.Gemeente.Land.LandId);
                    gemeente.LandId = land.LandId;
                }

                //check if gemeente exists
                var gemeenteService = new GemeenteService();
                var bestaandeGemeente = gemeenteService.GetGemeenteByPostcodeAndPlaats(tornooiViewModel.Gemeente.Postcode, tornooiViewModel.Gemeente.Plaats, tornooiViewModel.Gemeente.Land.LandId);
                if (bestaandeGemeente == null)
                {
                    gemeente.Postcode = tornooiViewModel.Gemeente.Postcode;
                    gemeente.Plaats = tornooiViewModel.Gemeente.Plaats;
                    nieuwTornooi.Gemeente = gemeente;
                }
                else
                {
                    nieuwTornooi.PostcodeId = bestaandeGemeente.PostcodeId;
                }

                nieuwTornooi.TornooiNaam = tornooiViewModel.TornooiNaam;
                nieuwTornooi.PlaatsNaam = tornooiViewModel.PlaatsNaam;
                nieuwTornooi.Adres = tornooiViewModel.Adres;
                nieuwTornooi.Huisnummer = tornooiViewModel.Huisnummer;
                nieuwTornooi.Datum = tornooiViewModel.Datum;
                nieuwTornooi.UitersteInschrijvingVoorAantalDagen = tornooiViewModel.UitersteInschrijvingVoorAantalDagen;

                //Get current club
                var userService = new UserService();
                var club = userService.GetCurrentClub();

                nieuwTornooi.ClubId = club.ClubId;

                //Checkboxes
                AddOrUpdateCategories(nieuwTornooi, tornooiViewModel.AssignedLeeftijdCategories);
                

                //Save nieuwtornooi
                var tornooiService = new TornooiService();
                bool save = tornooiService.Create(nieuwTornooi);
                
                return RedirectToAction("Index", new {@saved = save});
            }
            //Fill landen for dropdown
            var landen = landService.FindAll();
            ViewBag.Landen = landen;

            return View();
        }

        private static void AddOrUpdateCategories(Tornooi nieuwTornooi, ICollection<AssignedCategoriesViewModel> assignedCategories)
        {
            foreach (var assignedCategorie in assignedCategories)
            {
                if (assignedCategorie.Assigned)
                {
                    var leeftijdCatService = new LeeftijdCategorieService();
                    var cat = leeftijdCatService.Read(assignedCategorie.LeeftijdCategorieId);
                    nieuwTornooi.LeeftijdCategories.Add(cat);
                }
            }
        }

        //
        //GET : Tornooi/Verwijder
        public ActionResult Verwijder(int id)
        {
            var tornooiService = new TornooiService();
            tornooiService.Delete(id);
            return RedirectToAction("Index");
        }

        //
        //GET : Tornooi/Wijzig
        public ActionResult Wijzig(int id)
        {
            var tornooiService = new TornooiService();
            var tornooi = tornooiService.ReadWithGemeenteAndLandAndLeeftijdCategories(id);
            var tornooiViewModel = new TornooiViewModel()
            {
                TornooiId = tornooi.TornooiId,
                TornooiNaam = tornooi.TornooiNaam,
                PlaatsNaam = tornooi.PlaatsNaam,
                Adres = tornooi.Adres,
                Huisnummer = tornooi.Huisnummer,
                Datum = tornooi.Datum,
                UitersteInschrijvingVoorAantalDagen = tornooi.UitersteInschrijvingVoorAantalDagen,
                Gemeente = new Gemeente() { Postcode = tornooi.Gemeente.Postcode, Plaats = tornooi.Gemeente.Plaats, Land = new Land() { LandId = tornooi.Gemeente.Land.LandId, LandNaam = tornooi.Gemeente.Land.LandNaam} }
            };
            
            var leeftijdCategoriesService = new LeeftijdCategorieService();
            var leeftijdcategories = leeftijdCategoriesService.FindAll();
            
            var assignedLeeftijdCategories = new List<AssignedCategoriesViewModel>();
            foreach (var item in leeftijdcategories)
            {
                bool assigned = false;
                var item1 = item;
                var cat = tornooi.LeeftijdCategories.Where(m => m.LeeftijdCategorieId == item1.LeeftijdCategorieId);
                if (cat.Count()!=0)
                    assigned = true;
                assignedLeeftijdCategories.Add(new AssignedCategoriesViewModel
                {
                    LeeftijdCategorieId = item.LeeftijdCategorieId,
                    LeeftijdCategorieNaam = item.LeeftijdCategorieNaam,
                    Assigned = assigned
                });
            }
            tornooiViewModel.AssignedLeeftijdCategories = assignedLeeftijdCategories;

            //Fill landen for dropdown
            var landService = new LandService();
            var landen = landService.FindAll();
            ViewBag.Landen = landen;

            return View(tornooiViewModel);
        }

        //
        //POST : Tornooi/Wijzig
        [HttpPost]
        public ActionResult Wijzig(TornooiViewModel tornooi)
        {
            if (ModelState.IsValid)
            {
                var tornooiService = new TornooiService();
                var oudTornooi = tornooiService.ReadWithGemeenteAndLandAndLeeftijdCategories(tornooi.TornooiId);
                var nieuwTornooi = new Tornooi();
                AddOrUpdateCategories(nieuwTornooi, tornooi.AssignedLeeftijdCategories);
                int save=-1;
                if (tornooi.TornooiNaam != oudTornooi.TornooiNaam || tornooi.Datum != oudTornooi.Datum || tornooi.PlaatsNaam != oudTornooi.PlaatsNaam || tornooi.Adres != oudTornooi.Adres || tornooi.Huisnummer != oudTornooi.Huisnummer || tornooi.Gemeente.Postcode != oudTornooi.Gemeente.Postcode || tornooi.Gemeente.Plaats != oudTornooi.Gemeente.Plaats || tornooi.Gemeente.Land.LandId != oudTornooi.Gemeente.Land.LandId || tornooi.Gemeente.Land.LandNaam != oudTornooi.Gemeente.Land.LandNaam || !nieuwTornooi.LeeftijdCategories.Equals(oudTornooi.LeeftijdCategories) || tornooi.UitersteInschrijvingVoorAantalDagen != oudTornooi.UitersteInschrijvingVoorAantalDagen)
                {
                    save = tornooiService.Update(tornooi.TornooiId, tornooi.TornooiNaam, tornooi.Datum, tornooi.UitersteInschrijvingVoorAantalDagen, tornooi.PlaatsNaam, tornooi.Adres, tornooi.Huisnummer, tornooi.Gemeente.Postcode, tornooi.Gemeente.Plaats, tornooi.Gemeente.Land.LandId, tornooi.Gemeente.Land.LandNaam, tornooi.ClubId, nieuwTornooi.LeeftijdCategories);
                }
                return RedirectToAction("Index", new { @saved = save });
            }
            //Fill landen for dropdown
            var landService = new LandService();
            var landen = landService.FindAll();
            ViewBag.Landen = landen;

            return View();
        }
    }
}