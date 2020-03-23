using System.Data.Entity;
using BO_TP01Module06;

namespace TP01Module06_Partie_2.Data
{
    public class Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Context() : base("name=Context")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samourai>().HasMany(s => s.ArtsMartiaux).WithMany();
            modelBuilder.Entity<Samourai>().HasOptional(s => s.Arme).WithOptionalPrincipal();

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<BO_TP01Module06.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<BO_TP01Module06.Arme> Armes { get; set; }

        public System.Data.Entity.DbSet<BO_TP01Module06.ArtMartial> ArtMartials { get; set; }
    }
}
