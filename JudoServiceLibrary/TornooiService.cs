using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
                    foreach (var leeftijdCategory in tornooi.LeeftijdCategories)
                    {
                        db.LeeftijdCategorie.Attach(leeftijdCategory);
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
                return (from tornooi in db.Tornooi.Include("Gemeente").Include("Gemeente.Land").Include("LeeftijdCategories")
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
                return (from tornooi in db.Tornooi.Include("Gemeente").Include("Gemeente.Land").Include("LeeftijdCategories")
                        where tornooi.TornooiId == id
                        select tornooi).FirstOrDefault();
            }
        }

        public int Update(int id, string tornooiNaam, DateTime datum, int uitersteInschrijving, string plaatsnaam, string adres, string huisnummer, string postcode, string plaats, int landid, string landnaam, int clubid, ICollection<LeeftijdCategorie> leeftijdCategories )
        {
            if (tornooiNaam != null && plaatsnaam != null && adres != null && huisnummer != null && postcode != null && plaats != null && landnaam != null && leeftijdCategories != null)
            {
                using (var db = new JudoContext())
                {
                    var tornooiToUpdate = (from tornooi in db.Tornooi.Include("Gemeente").Include("LeeftijdCategories")
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
                        for (int i = 0; i < tornooiToUpdate.LeeftijdCategories.Count; i++)
                        {
                            var element = tornooiToUpdate.LeeftijdCategories.ElementAt(i);
                            tornooiToUpdate.LeeftijdCategories.Remove(element);
                            i--;
                        }

                        for (int i = 0; i < leeftijdCategories.Count; i++)
                        {
                            var cat = db.LeeftijdCategorie.Find(leeftijdCategories.ElementAt(i).LeeftijdCategorieId);
                            tornooiToUpdate.LeeftijdCategories.Add(cat);
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
                return (from tornooi in db.Tornooi.Include("Gemeente").Include("Gemeente.Land").Include("LeeftijdCategories")
                    where System.Data.Entity.DbFunctions.AddDays(tornooi.Datum, -tornooi.UitersteInschrijvingVoorAantalDagen) >= datum
                    select tornooi).ToList();
            }
        }
    }
}
