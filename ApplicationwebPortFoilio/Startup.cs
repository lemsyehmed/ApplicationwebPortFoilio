using Core.Interfaces;
using Infrastructure;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationwebPortFoilio
{
    public class Startup
    {
        
            private readonly IConfiguration Configuration;

            public Startup(IConfiguration configuration)
            {
                this.Configuration = configuration;
            }

            public void ConfigureServices(IServiceCollection services)
            {
                services.AddControllersWithViews();
                services.AddDbContext<DataContext>(Options =>
                {
                    Options.UseSqlServer(Configuration.GetConnectionString("MyPortFolioDb"));
                });
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                app.UseStaticFiles();

                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute("defaultRoute", "{controller=Home}/{action=Index}/{id?}");
                });
            }
        }
    }

