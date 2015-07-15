using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using JudoModelsLibrary;

namespace JudoServiceLibrary
{
    public class TornooiService
    {
        public bool Create(Tornooi tornooi)
        {
            if (tornooi != null)
            {
                using (var db = new JudoContext())
                {
                    foreach (var tornooileeftijdCategory in tornooi.TornooiLeeftijdCategories)
                    {
                        db.LeeftijdCategorie.Attach(tornooileeftijdCategory.LeeftijdCategorie);
                    }
                    db.Tornooi.Add(tornooi);
                    return db.SaveChanges() == 1;
                }
            }
            return false;
        }

        public List<Tornooi> GetTornooiByClub(int clubid)
        {
            using (var db = new JudoContext())
            {
                return (from tornooi in db.Tornooi.Include("Gemeente").Include("Gemeente.Land").Include("TornooiLeeftijdCategories").Include("TornooiLeeftijdCategories.LeeftijdCategorie")
                        where tornooi.ClubId == clubid
                        orderby tornooi.Datum
                        select tornooi).ToList();
            }
        }

        public bool Delete(int id)
        {
            using (var db = new JudoContext())
            {
                db.Tornooi.Remove((from tornooi in db.Tornooi
                                    where tornooi.TornooiId == id
                                    select tornooi).FirstOrDefault());
                return db.SaveChanges() == 1;
            }
        }

        public Tornooi Read(int id)
        {
            using (var db = new JudoContext())
            {
                return (from tornooi in db.Tornooi
                    where tornooi.TornooiId == id
                    select tornooi).FirstOrDefault();
            }
        }

        public Tornooi ReadWithGemeenteAndLandAndLeeftijdCategories(int id)
        {
            using (var db = new JudoContext())
            {
                return (from tornooi in db.Tornooi.Include("Gemeente").Include("Gemeente.Land").Include("TornooiLeeftijdCategories").Include("TornooiLeeftijdCategories.LeeftijdCategorie")
                        where tornooi.TornooiId == id
                        select tornooi).FirstOrDefault();
            }
        }

        public int Update(int id, string tornooiNaam, DateTime datum, int uitersteInschrijving, string plaatsnaam, string adres, string huisnummer, string postcode, string plaats, int landid, string landnaam, int clubid, ICollection<TornooiLeeftijdCategorie> tornooiLeeftijdCategories, decimal inschrijvingsgeld, string opmerkingen )
        {
            if (tornooiNaam != null && plaatsnaam != null && adres != null && huisnummer != null && postcode != null && plaats != null && landnaam != null && tornooiLeeftijdCategories != null && opmerkingen != null)
            {
                using (var db = new JudoContext())
                {
                    var tornooiToUpdate = (from tornooi in db.Tornooi.Include("Gemeente").Include("Gemeente.Land").Include("TornooiLeeftijdCategories").Include("TornooiLeeftijdCategories.LeeftijdCategorie")
                                           where tornooi.TornooiId == id
                                           select tornooi).FirstOrDefault();
                    if (tornooiToUpdate != null)
                    {
                        tornooiToUpdate.TornooiNaam = tornooiNaam;
                        tornooiToUpdate.Datum = datum;
                        tornooiToUpdate.PlaatsNaam = plaatsnaam;
                        tornooiToUpdate.Adres = adres;
                        tornooiToUpdate.Huisnummer = huisnummer;
                        tornooiToUpdate.UitersteInschrijvingVoorAantalDagen = uitersteInschrijving;
                        tornooiToUpdate.InschrijvingsGeld = inschrijvingsgeld;
                        tornooiToUpdate.Opmerkingen = opmerkingen;

                        var landService = new LandService();
                        Land land;
                        var gemeente = new Gemeente();
                        if(landid == -99) //Add another country chosen
                        {
                            //check if land exists
                            land = landService.GetLandByName(landnaam);
                            if(land == null)
                            {
                                //add new country
                                land = new Land{ LandNaam = landnaam};
                                gemeente.Land = land;
                            }
                            else
                            {
                                //get landid from existing country
                                gemeente.LandId = land.LandId;
                            }
                        }
                        else
                        {
                            land = landService.Read(landid);
                            gemeente.LandId = land.LandId;
                        }

                        //check if gemeente exists
                        var gemeenteService = new GemeenteService();
                        var bestaandeGemeente = gemeenteService.GetGemeenteByPostcodeAndPlaats(postcode, plaats, landid);
                        if(bestaandeGemeente == null)
                        {
                            gemeente.Postcode = postcode;
                            gemeente.Plaats = plaats;
                            tornooiToUpdate.Gemeente = gemeente;
                        }
                        else
                        {
                            tornooiToUpdate.PostcodeId = bestaandeGemeente.PostcodeId;
                        }

                        //Update LeeftijdCategories
                        for (int i = 0; i < tornooiToUpdate.TornooiLeeftijdCategories.Count; i++)
                        {
                            var element = tornooiToUpdate.TornooiLeeftijdCategories.ElementAt(i);
                            tornooiToUpdate.TornooiLeeftijdCategories.Remove(element);
                            i--;
                        }

                        for (int i = 0; i < tornooiLeeftijdCategories.Count; i++)
                        {
                            var cat = db.LeeftijdCategorie.Find(tornooiLeeftijdCategories.ElementAt(i).LeeftijdCategorie.LeeftijdCategorieId);
                            tornooiToUpdate.TornooiLeeftijdCategories.Add(new TornooiLeeftijdCategorie
                            {
                                LeeftijdCategorie = cat,
                                StartWeging = tornooiLeeftijdCategories.ElementAt(i).StartWeging,
                                EindeWeging= tornooiLeeftijdCategories.ElementAt(i).EindeWeging,
                                StartWedstrijden = tornooiLeeftijdCategories.ElementAt(i).StartWedstrijden
                            });
                        }
                    }
                    
                    return db.SaveChanges();
                }
            }
            return 0;
        }

        public List<Tornooi> GetTornooienNaDatum(DateTime datum)
        {
            using (var db = new JudoContext())
            {
                return (from tornooi in db.Tornooi.Include("Gemeente").Include("Gemeente.Land").Include("TornooiLeeftijdCategories").Include("TornooiLeeftijdCategories.LeeftijdCategorie")
                    where DbFunctions.AddDays(tornooi.Datum, -tornooi.UitersteInschrijvingVoorAantalDagen) >= datum
                    select tornooi).ToList();
            }
        }
    }
}
