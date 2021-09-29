using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AppLibrary
{
    public class Database : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Seat> Seats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var basedir = System.AppContext.BaseDirectory;
            var solndir = Directory.GetParent(basedir).Parent.Parent.Parent.Parent;
            options.UseSqlite($"Data Source={solndir.FullName}/db/app.db");

            // to disable change tracking
            // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            // db.Entry(some_obj).State = EntityState.Detached;

            // use either option below to log the queries to the console
            // options.LogTo(Console.WriteLine, LogLevel.Information);
            // options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));

            // displays parameter values in logs
            options.EnableSensitiveDataLogging();
        }
    }
}