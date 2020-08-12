using EsSample.Framework;
using Microsoft.EntityFrameworkCore;
using System;

namespace EsSample.EfStore
{
    public class EventStoreDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.; Database=EventStore ;User Id =sa;Password=1qaz!QAZ; MultipleActiveResultSets=true");
        }
        public DbSet<EventStoreItem> EventStoreItems { get; set; }
    }
}
