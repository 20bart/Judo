using JudoModelsLibrary;

namespace JudoServiceLibrary
{
    public class RekeningnummerService
    {
        public void Create(RekeningNummer rekeningNummer)
        {
            if (rekeningNummer == null) return;
            using (var db = new JudoContext())
            {
                db.Rekeningnummer.Add(rekeningNummer);
                db.SaveChanges();
            }
        }
    }
}