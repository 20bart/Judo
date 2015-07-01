using System.Linq;
using JudoModelsLibrary;

namespace JudoServiceLibrary
{
    public class ClubService
    {
        public void Create(Club club)
        {
            if (club != null)
            {
                using (var db = new JudoContext())
                {
                    db.Club.Add(club);
                    db.SaveChanges();
                }
            }
        }

        public Club Read(int clubid)
        {
            using (var db = new JudoContext())
            {
                return (from club in db.Club
                        where club.ClubId == clubid
                        select club).FirstOrDefault();
            }
        }

        public Club ReadWithGemeenteAndLand(int clubid)
        {
            using (var db = new JudoContext())
            {
                return (from club in db.Club.Include("Gemeente").Include("Gemeente.Land")
                        where club.ClubId == clubid
                        select club).FirstOrDefault();
            }
        }

        public bool Update(Club club)
        {
            if (club != null)
            {
                using (var db = new JudoContext())
                {
                    var clubToUpdate = (from c in db.Club.Include("Gemeente").Include("Gemeente.Land")
                                        where c.ClubId == club.ClubId
                                        select c).FirstOrDefault();
                    clubToUpdate = club;
                    if (db.SaveChanges() != 0)
                        return true;
                }
            }
            return false;
        }

        public bool Update(int id, string clubnummer, string clubnaam, string straat, string huisnummer, string postcode, string plaats, int landid, string landnaam)
        {
            if(clubnummer!=null && clubnaam!=null && straat!=null && huisnummer!=null && postcode!=null && plaats!=null && landnaam!=null)
            {
                using (var db = new JudoContext())
                {
                    var clubToUpdate = (from club in db.Club.Include("Gemeente")
                                        where club.ClubId == id
                                        select club).FirstOrDefault();
                    clubToUpdate.ClubNummer = clubnummer;
                    clubToUpdate.Naam = clubnaam;
                    clubToUpdate.Adres = straat;
                    clubToUpdate.Huisnummer = huisnummer;
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
                        clubToUpdate.Gemeente = gemeente;
                    }
                    else
                    {
                        clubToUpdate.PostcodeId = bestaandeGemeente.PostcodeId;
                    }
                    return db.SaveChanges() != 0;
                }
            }
            return false;
        }

        public bool ClubExists(string clubnummer, int landid)
        {
            if (clubnummer != null)
            {
                using (var db = new JudoContext())
                {
                    var bestaandeClub = (from club in db.Club.Include("Gemeente.Land")
                                         where club.ClubNummer == clubnummer && club.Gemeente.Land.LandId == landid
                                         select club).FirstOrDefault();
                    if (bestaandeClub != null)
                        return true;
                }
            }
            return false;
        }

        public Club GetClubByEmailWithVerantwoordelijke(string email)
        {
            if(email!=null)
            {
                using (var db = new JudoContext())
                {
                    return (from club in db.Club.Include("Verantwoordelijke")
                            where club.Verantwoordelijke.Email == email
                            select club).FirstOrDefault();
                }
            }
            return null;
        }

        public Club GetClubByEmailWithGemeenteAndLand(string email)
        {
            if (email != null)
            {
                using (var db = new JudoContext())
                {
                    return (from club in db.Club.Include("Gemeente").Include("Gemeente.Land")
                            where club.Verantwoordelijke.Email == email
                            select club).FirstOrDefault();
                }
            }
            return null;
        }

    }
}