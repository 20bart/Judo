using System.Collections.Generic;
using System.Linq;
using JudoModelsLibrary;

namespace JudoServiceLibrary
{
    public class LeeftijdCategorieService
    {
        public List<LeeftijdCategorie> FindAll()
        {
            using (var db = new JudoContext())
            {
                return (from cat in db.LeeftijdCategorie
                    select cat).ToList();
            }
        }

        public LeeftijdCategorie Read(int id)
        {
            using (var db = new JudoContext())
            {
                return (from cat in db.LeeftijdCategorie
                    where cat.LeeftijdCategorieId == id
                    select cat).FirstOrDefault();
            }
        }
    }
}
