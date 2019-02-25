using BusinessFacade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class GmmContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Optreden> Optredens { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Tent> Tents { get; set; }
        public DbSet<Kleedkamer> Kleedkamers { get; set; }
        public DbSet<ProductieUnit> ProductieUnits { get; set; }
        public DbSet<BandKleedkamers> BandKleedkamers { get; set; }
        public DbSet<BandProductieUnits> BandProductieUnits { get; set; }
        public DbSet<Voorziening> Voorzienings { get; set; }
        public DbSet<Catering> Caterings { get; set; }
        public DbSet<Logistic> Logistics { get; set; }
        public DbSet<Special> Specials { get; set; }

        public GmmContext(DbContextOptions<GmmContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
