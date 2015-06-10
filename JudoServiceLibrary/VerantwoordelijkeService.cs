using System.Linq;
using JudoModelsLibrary;

namespace JudoServiceLibrary
{
    public class VerantwoordelijkeService
    {
        public void Create(Verantwoordelijke verantw)
        {
            if (verantw != null)
            {
                using (var db = new JudoContext())
                {
                    db.Verantwoordelijke.Add(verantw);
                    db.SaveChanges();
                }
            }
        }

        public bool Update(int id, string voornaam, string familienaam, string email, string telefoonnummer)
        {
            if (voornaam != null && familienaam != null && email != null && telefoonnummer != null)
            {
                using (var db = new JudoContext())
                {
                    var verantw = (from verantwoordelijke in db.Verantwoordelijke
                                   where verantwoordelijke.VerantwoordelijkeId == id
                                   select verantwoordelijke).FirstOrDefault();
                    verantw.Voornaam = voornaam;
                    verantw.Familienaam = familienaam;
                    verantw.Email = email;
                    verantw.Telefoonnummer = telefoonnummer;
                    if (db.SaveChanges() != 0)
                        return true;
                }
            }
            return false;
        }

        public Verantwoordelijke GetVerantwoordelijkeByEmail(string email)
        {
            if (email != null)
            {
                using (var db = new JudoContext())
                {
                    return (from verantw in db.Verantwoordelijke
                            where verantw.Email == email
                            select verantw).FirstOrDefault();
                }
            }
            return null;
        }
    }
}