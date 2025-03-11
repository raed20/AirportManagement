using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.domain;
using AM.Infrastructure.configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
         //DBSET 
         public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellerss { get; set; }
        public DbSet<Ticket>Tickets { get; set; }
        

        //OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                         Initial Catalog=AirportManagementDB;
                                         Integrated Security=true;
                                         MultipleActiveResultSets= True");
            //to unblock jointure
            optionsBuilder.UseLazyLoadingProxies(); 
            base.OnConfiguring(optionsBuilder);
        }
        //OnModelCreating (FluentAPI)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1er methode
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            //2eme methode
            // modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
            //modelBuilder.Entity<Plane>().ToTable("MyPlanes");
            //modelBuilder.Entity<Plane>().Property(P=>P.Capacity).HasColumnName("PlaneCapacity");
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //configure owned type
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName);

            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            //tph , heritage automatique effectué par l orm
            //modelBuilder.Entity<Passenger>()
            //    .HasDiscriminator<int>("IsTraveller")
            //    .HasValue<Passenger>(2)
            //    .HasValue<Traveller>(1)
            //    .HasValue<Staff>(0);

            //configuer l'heritage table per type TPT
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");
            //configurer la clé primaire  de la porteuse de données
            modelBuilder.Entity<Ticket>()
                .HasKey(t => new { t.FlightFk, t.PassengerFk });

            base.OnModelCreating(modelBuilder);


          
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                .HaveColumnType("datetime");

            base.ConfigureConventions(configurationBuilder);
        }

       
    }

}
