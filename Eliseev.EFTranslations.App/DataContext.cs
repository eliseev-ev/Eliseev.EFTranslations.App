using Eliseev.EFTranslations.App.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Eliseev.EFTranslations.App
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base()
        {
            //SQLitePCL.Batteries_V2.Init();
            //this.Database.EnsureCreated();

            if (this.Database.EnsureCreated())
            {
                Populate();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Ждем когда заработает sqlite на maui
            //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "entities.db3");
            //optionsBuilder
            //    .UseSqlite($"Filename={dbPath}");
            optionsBuilder.UseInMemoryDatabase("db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Group>()
            //    .HasMany(x => x.Groups)
            //    .WithOne()
            //    .HasForeignKey(x => x.CounterGroupId);

            modelBuilder.Entity<SomeEntity>()
                .Property(x => x.Name)
                //.ValueGeneratedOnAddOrUpdate()
                .HasValueGenerator(((x, y)
                => new CustomGenerator<SomeEntity, string>((x) => x.Id.ToString())));
        }

        public DbSet<SomeEntity> SomeEntities { get; set; }




        private void Populate()
        {
            this.SomeEntities.Add(new SomeEntity
            {
                ////Name = "jhg"
            });


            this.SaveChanges();

        }
    }


    public class CustomGenerator<TEntityType, TProperty> : ValueGenerator<TProperty>
    {
        private readonly Func<TEntityType, TProperty> factoryGenerateValue;

        public CustomGenerator(Func<TEntityType, TProperty> factoryGenerateValue)
        {
            this.factoryGenerateValue = factoryGenerateValue;
        }

        public override TProperty Next(EntityEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            return factoryGenerateValue.Invoke((TEntityType)entry.Entity);
        }

        public override bool GeneratesTemporaryValues { get; }
    }
   
}