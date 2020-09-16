using Microsoft.EntityFrameworkCore;
using Session09.Core.Domain.People.Entities;
using Session09.Infra.Data.Command.Sql.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session09.Infra.Data.Command.Sql
{
    public class Session09DbContext:DbContext
    {
        public DbSet<Person> People { get; set; }

        public Session09DbContext(DbContextOptions<Session09DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
