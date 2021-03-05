using Microsoft.EntityFrameworkCore;
using ProductManagement.Core.Domain.Categories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Infra.Data.Sql.Commands;

namespace ProductManagement.Infra.Data.Sql.Commands.Common
{
    public class ProductManagementCommandDbContext : BaseCommandDbContext
    {
        #region Constructors
        public ProductManagementCommandDbContext(DbContextOptions<ProductManagementCommandDbContext> options) : base(options)
        {
        }
        public ProductManagementCommandDbContext()
        {

        }
        #endregion

        #region DbSets
        public DbSet<Category> Categories { get; set; }
        #endregion


        #region overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        #endregion
    }
}
