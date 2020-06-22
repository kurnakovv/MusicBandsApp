using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicianBandsApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("MusicBandsDb") { }

        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Band> Bands { get; set; }
    }
}