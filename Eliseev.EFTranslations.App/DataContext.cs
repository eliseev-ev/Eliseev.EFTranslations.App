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
            //this.Database.EnsureCreated();

            if (this.Database.EnsureCreated())
            {
                //Populate();
            }
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
                .PropertyValueGenerator(x => x.Property3, x => x.Id.ToString());

        }

        public DbSet<SomeEntity> SomeEntities { get; set; }


        //private void Populate()
        //{
        //    this.SomeEntities.AddRange(
        //            new SomeEntity
        //            {
        //                Name3 = "NoGen"
        //            },
        //           new SomeEntity { }
        //        );


        //    this.SaveChanges();
        //}
    }

}