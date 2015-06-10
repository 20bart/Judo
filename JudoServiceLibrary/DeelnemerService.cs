using System.Collections.Generic;
using System.Linq;
using JudoModelsLibrary;

namespace JudoServiceLibrary
{
    public class DeelnemerService
    {
        public void Create(Deelnemer deelnemer)
        {
            if (deelnemer != null)
            {
                using (var db = new JudoContext())
                {
                    db.Deelnemer.Add(deelnemer);
                    db.SaveChanges();
                }
            }
        }

        public bool DeelnemerExists(string voornaam, string familienaam, int geboortejaar, Geslacht geslacht, int clubid)
        {
            if (voornaam!=null && familienaam!=null)
            {
                using(var db = new JudoContext())
	            {
                    var existingDeelnemer = (from deelnemer in db.Deelnemer
                                            where deelnemer.Voornaam == voornaam && deelnemer.Familienaam == familienaam && deelnemer.GeboorteJaar == geboortejaar && deelnemer.Geslacht == geslacht && deelnemer.ClubId == clubid
                                            select deelnemer).FirstOrDefault();
                    if (existingDeelnemer != null)
                        return true;
                }
            }
            return false;
        }

        public List<Deelnemer> FindAll()
        {
            using (var db = new JudoContext())
            {
                return (from deelnemer in db.Deelnemer
                        orderby deelnemer.Familienaam, deelnemer.Voornaam
                        select deelnemer).ToList();
            }
        }

        public Deelnemer Read(int id)
        {
            using (var db = new JudoContext())
            {
                return (from deelnemer in db.Deelnemer
                        where deelnemer.DeelnemersId == id
                        select deelnemer).FirstOrDefault();
            }
        }

        public bool Update(Deelnemer model)
        {
            using (var db = new JudoContext())
            {
                var deelnemerToUpdate = (from deelnemer in db.Deelnemer
                                         where deelnemer.DeelnemersId == model.DeelnemersId
                                         select deelnemer).FirstOrDefault();
                // ReSharper disable once RedundantAssignment
                deelnemerToUpdate = model;
                if (db.SaveChanges() != 0)
                    return true;
            }
            return false;
        }

        public bool Update(int id, string familienaam, string voornaam, int geboortejaar, Geslacht geslacht)
        {
            using (var db = new JudoContext())
            {
                var deelnemerToUpdate = (from deelnemer in db.Deelnemer
                                         where deelnemer.DeelnemersId == id
                                         select deelnemer).FirstOrDefault();
                deelnemerToUpdate.Familienaam = familienaam;
                deelnemerToUpdate.Voornaam = voornaam;
                deelnemerToUpdate.GeboorteJaar = geboortejaar;
                deelnemerToUpdate.Geslacht = geslacht;
                if (db.SaveChanges() != 0)
                    return true;
            }
            return false;
        }

        public List<Deelnemer> GetDeelnemersFromClub(int clubid)
        {
            using (var db = new JudoContext())
            {
                return (from deelnemer in db.Deelnemer
                        where deelnemer.ClubId == clubid
                        orderby deelnemer.Voornaam, deelnemer.Familienaam
                        select deelnemer).ToList();
            }
        }

        public void Delete(int id)
        {
            using (var db = new JudoContext())
            {
                db.Deelnemer.Remove((from deelnemer in db.Deelnemer
                                     where deelnemer.DeelnemersId == id
                                     select deelnemer).FirstOrDefault());
                db.SaveChanges();
            }
        }
    }
}