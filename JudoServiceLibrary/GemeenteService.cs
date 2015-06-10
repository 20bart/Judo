using System.Collections.Generic;
using System.Linq;
using JudoModelsLibrary;

namespace JudoServiceLibrary
{
    public class GemeenteService
    {
        public void Create(Gemeente gemeente)
        {
            if (gemeente != null)
            {
                using (var db = new JudoContext())
                {
                    db.Gemeente.Add(gemeente);
                    db.SaveChanges();
                }
            }
        }


        public List<Gemeente> FindAll()
        {
            using(var db = new JudoContext())
	        {
                return (from gemeente in db.Gemeente
                        orderby gemeente.Plaats
                        select gemeente).ToList();
            }
        }

        public Gemeente GetGemeenteByPostcodeAndPlaats(string postcode, string plaats, int landid)
        {
            if(postcode!=string.Empty && plaats!=string.Empty)
            {
                using (var db = new JudoContext())
                {
                    return (from gemeente in db.Gemeente.Include("Land")
                            where gemeente.Postcode == postcode && gemeente.Plaats == plaats && gemeente.Land.LandId == landid
                            select gemeente).FirstOrDefault();
                }
            }
            return null;
        }

        public bool GemeenteExists(string postcode, string plaats, int landid)
        {
            if (postcode != null && plaats != null)
            {
                using (var db = new JudoContext())
                {
                    return (from gemeente in db.Gemeente.Include("Land")
                            where gemeente.Postcode == postcode && gemeente.Plaats == plaats && gemeente.Land.LandId == landid
                            select gemeente).FirstOrDefault() != null;
                }
            }
            return false;
        }
    }
}