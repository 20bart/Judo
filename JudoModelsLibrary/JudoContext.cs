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
    }
}