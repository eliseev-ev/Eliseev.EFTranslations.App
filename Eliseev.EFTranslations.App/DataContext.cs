using Eliseev.EFTranslations.App.Insrastructure;
using Eliseev.EFTranslations.App.Models;
using Microsoft.EntityFrameworkCore;



namespace Eliseev.EFTranslations.App
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////modelBuilder.Entity<SomeEntity>()
            ////    .Property(x => x.Name)
            ////    .HasValueGenerator<SomeEntity, string>(x => x.Id.ToString());


            modelBuilder.Entity<SomeEntity>()
                .PropertyValueGenerator(x => x.Property1, x => x.Id.ToString())
                .PropertyValueGenerator(x => x.Property2, x => x.Id.ToString())
                .PropertyValueGenerator(x => x.Property3, x => x.Id.ToString())
                .PropertyValueGenerator(x => x.Property4, x => x.Property1.ToString() + x.Property2.ToString());

        }

        public DbSet<SomeEntity> SomeEntities { get; set; }
    }
}