  
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreConstructorAngular;
using NetCoreConstructorAngular.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blazor.Core
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    
        public void ConfigureServices(IServiceCollection services)
        {
                  
        }
         

        
    }
}
