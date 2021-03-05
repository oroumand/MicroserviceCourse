using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductManagement.Infra.Data.Sql.Commands.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zamin.EndPoints.Web.StartupExtentions;
using Zamin.Utilities.Configurations;

namespace ProductManagement.EndPoints.API
{
    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddZaminApiServices(Configuration);
            services.AddDbContext<ProductManagementCommandDbContext>
                (c => c.UseSqlServer(Configuration.GetConnectionString("ProductManagement_ConnectionString")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            ZaminConfigurations zaminConfigurations)
        {
            app.UseZaminApiConfigure(zaminConfigurations, env);
        }
    }
}
