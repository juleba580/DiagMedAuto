using Microsoft.EntityFrameworkCore;

namespace DiagMedAuto.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Utilisation de MySql pour la liaison de la base de donnees
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=diaghospital;Uid=root;",
                new MySqlServerVersion(new Version(8, 0, 26)));
        }
    }
}
