using BobaTrackerClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BobaTrackerDataAccessLayer
{
    public class BobaTrackerDBContext : DbContext
    {
        public DbSet<Entry> Entries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("BobaDBConnectionString");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(@connectionString);
            }
            //optionsBuilder.UseSqlite(@"C:\Temp\Demo.db");
        }
        
    }
}
