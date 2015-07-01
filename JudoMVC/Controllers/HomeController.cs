using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
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

            //using (var db = new JudoContext())
            //{
            //    var leeftijdCategorieen = new List<LeeftijdCategorie>()
            //    {
            //        new LeeftijdCategorie() { LeeftijdCategorieNaam = "U11", LeeftijdBegin = 9, LeeftijdEinde = 10},
            //        new LeeftijdCategorie() { LeeftijdCategorieNaam = "U13", LeeftijdBegin = 11, LeeftijdEinde = 12 },
            //        new LeeftijdCategorie() { LeeftijdCategorieNaam = "U15", LeeftijdBegin = 13, LeeftijdEinde = 14 },
            //        new LeeftijdCategorie() { LeeftijdCategorieNaam = "U18", LeeftijdBegin = 15, LeeftijdEinde = 17 },
            //        new LeeftijdCategorie() { LeeftijdCategorieNaam = "U21", LeeftijdBegin = 18, LeeftijdEinde = 20 },
            //        new LeeftijdCategorie() { LeeftijdCategorieNaam = "+21", LeeftijdBegin = 21, LeeftijdEinde = 99 }
            //    };
            //    db.LeeftijdCategorie.AddRange(leeftijdCategorieen);

            //    var duurCategorieen = new List<DuurCategorie>()
            //    {
            //        new DuurCategorie() {Duur = TimeSpan.FromMinutes(1.5d)},
            //        new DuurCategorie() {Duur = TimeSpan.FromMinutes(2d)},
            //        new DuurCategorie() {Duur = TimeSpan.FromMinutes(3d)},
            //        new DuurCategorie() {Duur = TimeSpan.FromMinutes(4d)},
            //        new DuurCategorie() {Duur = TimeSpan.FromMinutes(5d)}
            //    };
            //    db.DuurCategorie.AddRange(duurCategorieen);

            //    var gewichtCategorieen = new List<GewichtCategorie>()
            //    {
            //        new GewichtCategorie() {Gewicht = 32, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 34, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 36, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 38, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 40, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 42, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 44, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 46, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 48, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 50, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 52, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 55, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 57, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 60, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 63, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 63, Sign = "+"},
            //        new GewichtCategorie() {Gewicht = 66, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 66, Sign = "+"},
            //        new GewichtCategorie() {Gewicht = 70, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 70, Sign = "+"},
            //        new GewichtCategorie() {Gewicht = 73, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 78, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 78, Sign = "+"},
            //        new GewichtCategorie() {Gewicht = 81, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 90, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 90, Sign = "+"},
            //        new GewichtCategorie() {Gewicht = 100, Sign = "-"},
            //        new GewichtCategorie() {Gewicht = 100, Sign = "+"}
            //    };
            //    db.GewichtCategorie.AddRange(gewichtCategorieen);
            //    db.SaveChanges();
            //    var categorieen = new List<Categorie>()
            //    {
            //        //U11 Mannen
            //        new Categorie(){LeeftijdCategorieId = 1, Geslacht = Geslacht.Man, DuurCategorieId = 1,Individueel = true},
            //        //U11 Vrouwen
            //        new Categorie(){LeeftijdCategorieId = 1, Geslacht = Geslacht.Vrouw, DuurCategorieId = 1,Individueel = true},
            //        //U13 Mannen
            //        new Categorie(){LeeftijdCategorieId = 2, Geslacht = Geslacht.Man, DuurCategorieId = 2,Individueel = true},
            //        //U13 Vrouwen
            //        new Categorie(){LeeftijdCategorieId = 2, Geslacht = Geslacht.Vrouw, DuurCategorieId = 2,Individueel = true},
            //        //U15 Mannen
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Man, GewichtCategorieId = 2,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Man, GewichtCategorieId = 4,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Man, GewichtCategorieId = 6,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Man, GewichtCategorieId = 8,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Man, GewichtCategorieId = 10,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Man, GewichtCategorieId = 12,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Man, GewichtCategorieId = 14,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Man, GewichtCategorieId = 17,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Man, GewichtCategorieId = 18,DuurCategorieId = 3,Individueel = true},
            //        //U15 Vrouwen
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 1,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 3,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 5,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 7,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 9,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 11,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 13,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 15,DuurCategorieId = 3,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 3, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 16,DuurCategorieId = 3,Individueel = true},
            //        //U18 Mannen
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Man, GewichtCategorieId = 6,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Man, GewichtCategorieId = 8,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Man, GewichtCategorieId = 10,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Man, GewichtCategorieId = 12,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Man, GewichtCategorieId = 14,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Man, GewichtCategorieId = 17,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Man, GewichtCategorieId = 21,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Man, GewichtCategorieId = 24,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Man, GewichtCategorieId = 25,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Man, GewichtCategorieId = 26,DuurCategorieId = 4,Individueel = true},
            //        //U18 Vrouwen
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 5,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 7,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 9,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 11,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 13,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 15,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 19,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 4, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 20,DuurCategorieId = 4,Individueel = true},
            //        //U21 Mannen
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Man, GewichtCategorieId = 12,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Man, GewichtCategorieId = 14,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Man, GewichtCategorieId = 17,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Man, GewichtCategorieId = 21,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Man, GewichtCategorieId = 24,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Man, GewichtCategorieId = 25,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Man, GewichtCategorieId = 27,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Man, GewichtCategorieId = 28,DuurCategorieId = 4,Individueel = true},
            //        //U21 Vrouwen
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 7,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 9,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 11,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 13,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 15,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 19,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 22,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 5, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 23,DuurCategorieId = 4,Individueel = true},
            //        //+21 Mannen
            //        new Categorie(){LeeftijdCategorieId = 6, Geslacht = Geslacht.Man, GewichtCategorieId = 14,DuurCategorieId = 5,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 6, Geslacht = Geslacht.Man, GewichtCategorieId = 17,DuurCategorieId = 5,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 6, Geslacht = Geslacht.Man, GewichtCategorieId = 21,DuurCategorieId = 5,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 6, Geslacht = Geslacht.Man, GewichtCategorieId = 24,DuurCategorieId = 5,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 6, Geslacht = Geslacht.Man, GewichtCategorieId = 25,DuurCategorieId = 5,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 6, Geslacht = Geslacht.Man, GewichtCategorieId = 27,DuurCategorieId = 5,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 6, Geslacht = Geslacht.Man, GewichtCategorieId = 28,DuurCategorieId = 5,Individueel = true},
            //        //+21 Vrouwen
            //        new Categorie(){LeeftijdCategorieId = 6, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 9,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 6, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 11,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 6, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 13,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 6, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 15,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 6, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 19,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 6, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 22,DuurCategorieId = 4,Individueel = true},
            //        new Categorie(){LeeftijdCategorieId = 6, Geslacht = Geslacht.Vrouw, GewichtCategorieId = 23,DuurCategorieId = 4,Individueel = true}
            //    };
            //    db.Categorie.AddRange(categorieen);
            //    db.SaveChanges();
            //}

            
            
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