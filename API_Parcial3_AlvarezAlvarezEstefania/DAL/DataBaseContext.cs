using API_Parcial3_AlvarezAlvarezEstefania.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace API_Parcial3_AlvarezAlvarezEstefania.DAL
{
    public class DataBaseContext: DbContext
    {
        
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasIndex("Name", "City").IsUnique(); 
            modelBuilder.Entity<Room>().HasIndex("Number", "HotelId").IsUnique(); 
        }

        #region DbSets

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }

        #endregion
    }
}
