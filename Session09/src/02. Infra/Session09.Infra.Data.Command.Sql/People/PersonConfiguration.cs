using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Session09.Core.Domain.People.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zamin.Core.Domain.TacticalPatterns;

namespace Session09.Infra.Data.Command.Sql.People
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(c => c.Id).HasConversion(c => c.Value, c => BusinessId.FromGuid(c));        }
    }
}
