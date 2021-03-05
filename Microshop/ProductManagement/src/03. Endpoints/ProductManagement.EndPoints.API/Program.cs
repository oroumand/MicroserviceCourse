using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zamin.EndPoints.Web;

namespace ProductManagement.EndPoints.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new ZaminProgram().Main(args, typeof(Startup), "appsettings.json", "appsettings.zamin.json", "appsettings.serilog.json");
        }

    }
}
