using JudoModelsLibrary;

namespace JudoServiceLibrary
{
    class TornooiService
    {
        public void Create(Tornooi tornooi)
        {
            if (tornooi != null)
            {
                using (var db = new JudoContext())
                {
                    db.Tornooi.Add(tornooi);
                    db.SaveChanges();
                }
            }
        }
    }
}
