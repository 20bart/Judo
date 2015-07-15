using System.Data.Entity;

namespace JudoModelsLibrary
{
    public class JudoContext: DbContext
    {
        public DbSet<Club> Club { get; set; }
        public DbSet<Deelnemer> Deelnemer { get; set; }
        public DbSet<Gemeente> Gemeente { get; set; }
        public DbSet<InschrDeelnemer> InschrDeelnemer { get; set; }
        public DbSet<InschrijvingsFormulier> InschrijvingsFormulier { get; set; }
        public DbSet<Land> Land { get; set; }
        public DbSet<Tornooi> Tornooi { get; set; }
        public DbSet<Verantwoordelijke> Verantwoordelijke { get; set; }
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<LeeftijdCategorie> LeeftijdCategorie { get; set; }
        public DbSet<GewichtCategorie> GewichtCategorie { get; set; }
        public DbSet<DuurCategorie> DuurCategorie { get; set; }
        public DbSet<RekeningNummer> Rekeningnummer { get; set; }
    }
}