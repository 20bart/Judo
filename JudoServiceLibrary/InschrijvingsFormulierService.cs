using JudoModelsLibrary;

namespace JudoServiceLibrary
{
    public class InschrijvingsFormulierService
    {
        public void Create(InschrijvingsFormulier inschrijvingsForm)
        {
            if (inschrijvingsForm != null)
            {
                using (var db = new JudoContext())
                {
                    db.InschrijvingsFormulier.Add(inschrijvingsForm);
                    db.SaveChanges();
                }
            }
        }
    }
}
