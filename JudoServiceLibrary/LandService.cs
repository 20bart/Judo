using System.Collections.Generic;
using System.Linq;
using JudoModelsLibrary;

namespace JudoServiceLibrary
{
    public class LandService
    {
        public void Create(Land land)
        {
            if (land != null)
            {
                using (var db = new JudoContext())
                {
                    db.Land.Add(land);
                    db.SaveChanges();
                }
            }
        }

        public List<Land> FindAll()
        {
            using (var db = new JudoContext())
            {
                var landen = (from land in db.Land
                        orderby land.LandNaam
                        select land).ToList();
                if (landen != null)
                    return landen;
            }
            return null;
        }

        public Land Read(int id)
        {
            using (var db = new JudoContext())
            {
                return (from land in db.Land
                        where land.LandId == id
                        select land).FirstOrDefault();
            }
        }

        public Land GetLandByName(string landnaam)
        {
            if (landnaam!=null)
            {
                using (var db = new JudoContext())
                {
                    return (from land in db.Land
                            where land.LandNaam == landnaam
                            select land).FirstOrDefault();
                }
            }
            return null;
        }

        public bool LandExists(string landnaam)
        {
            if (landnaam != null)
            {
                using (var db = new JudoContext())
                {
                    return (from land in db.Land
                            where land.LandNaam == landnaam
                            select land).FirstOrDefault() != null;
                }
            }
            return false;
        }
    }
}