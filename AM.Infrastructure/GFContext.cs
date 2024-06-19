using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AM.Infrastructure
{
    public class GFContext: DbContext
    {
        public DbSet<Artiste> Artistes { get; set; }
        public DbSet<Chanson> Chansons { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Concert> Concerts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
              Initial Catalog=FestDB;Integrated Security=true;
              MultipleActiveResultSets=true");
                 
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Concert>()
                .HasOne(c => c.Artiste).WithMany(a => a.Concerts).HasForeignKey(c => c.ArtisteFk);
            modelBuilder.Entity<Concert>().HasOne(c => c.Festival).WithMany(f => f.Concerts).HasForeignKey(c => c.FestivalFk);
            modelBuilder.Entity<Concert>().HasKey(c => new { c.DateConcert, c.ArtisteFk, c.FestivalFk });

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //    // Pre-convention model configuration goes here
            //    configurationBuilder
            //        .Properties<string>()
            //        .HaveMaxLength(50);
            //configurationBuilder
            //    .Properties<decimal>()
            //        .HavePrecision(8,3);
            configurationBuilder
              .Properties<string>().HaveMaxLength(30);
        }



    }
}
