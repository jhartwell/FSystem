using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FSystem.Common.Interfaces;
using FSystem.Common;
using FSystem.Api.Model;

namespace FSystem.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            ConfigureFSystemDeps(services);

        }

        // Wire up the dependencies we created in our own libraries
        private void ConfigureFSystemDeps(IServiceCollection services)
        {
            services.AddScoped(typeof(IFormat), typeof(JsonFormat));
            services.AddScoped(typeof(IInputService), typeof(InputService));
            services.AddScoped(typeof(IOutputService), typeof(OutputService));
            services.AddScoped(typeof(IReader), typeof(Reader));
            services.AddScoped(typeof(IRecord), typeof(Record));
            services.AddSingleton(typeof(IDataStore), typeof(DataStore));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
