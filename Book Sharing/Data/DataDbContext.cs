using Book_Sharing.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Book_Sharing.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DAO_Utente> Utenti { get; set; }
        public DbSet<DAO_UtenteLibro> UtentiLibri { get; set; }
        public DbSet<Regione> Regioni { get; set; }
        public DbSet<Provincia> Province { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DAO_Utente>()
                .HasMany(e => e.Posseduti)
                .WithOne(e => e.Utente)
                .HasForeignKey(e => e.fkUtente)
                .HasPrincipalKey(e => e.PkUtente);

            modelBuilder.Entity<Regione>()
    .HasMany(e => e.Province)
    .WithOne(e => e.Regione)
    .HasForeignKey(e => e.fkRegione)
    .HasPrincipalKey(e => e.PkRegione);

            modelBuilder.Entity<Provincia>()
    .HasMany(e => e.Utenti)
    .WithOne(e => e.Provincia)
    .HasForeignKey(e => e.fkProvincia)
    .HasPrincipalKey(e => e.PkProvincia);
        }
    }
}
