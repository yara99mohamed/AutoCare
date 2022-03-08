using AutoCare.Models;
using AutoCare.Models.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare
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
            services.AddControllersWithViews();
            services.AddDbContext<AutoCareContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("AutoCare")));
            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<AutoCareContext>();
            services.AddScoped<IAutoRepository<Car>, CarRepository>();
            services.AddScoped<IAutoRepository<User>, UsersRepoistory>();
            services.AddScoped<IAutoRepository<Services>, ServicesRepository>();
            services.AddScoped<IAutoRepository<CheckUpsServices>, CheckUpsServicesReposatory>();
            services.AddScoped<IAutoRepository<CheckUpsSpareParts>, CheckUpsSparePartsReposatory>();

            services.AddScoped<IAutoRepository<Models.Type>, TypesRepository>();
            services.AddScoped<IAutoRepository<CheckUps>, CheckUpsRepoistory>();
            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions() { 
            ProgressBar=true,
            PositionClass=ToastPositions.TopRight,
            CloseButton=true,
            PreventDuplicates=true
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Car}/{action=Index}/{id?}");
            });
        }
    }
}
