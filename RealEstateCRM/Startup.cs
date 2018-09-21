using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountCore.DataModels;
using AccountCore.Repositories;
using AccountCore.Repositories.Interfaces;
using AccountCore.ServiceInjects;
using CRM.DatabaseModelLayer.Context;
using CRM.DatabaseServiceLayer.ServiceInject;
using CRM.DatabaseServiceLayer.Services.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace RealEstateCRM
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
			services.AddMvc();
			services.AddEntityFrameworkSqlServer();
			var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
			services.AddDbContext<ApplicationDB>(options => options.UseSqlServer(connectionString));
			services.AddIdentity<ApplicationUsers, ApplicationRoles>(identity =>
			{
				identity.Password = new PasswordOptions { RequiredLength = 5 };
				identity.SignIn = new SignInOptions { RequireConfirmedEmail = true, RequireConfirmedPhoneNumber = false };
				identity.User = new UserOptions { RequireUniqueEmail = true };
			});


			services.AddAccountManager();
			services.AddEntitiesWithUnitofWork();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

			app.UseAuthentication();
			app.UseStaticFiles();
            app.UseMvc(routes =>
            {
				routes.MapRoute(
				name: "areaRoute",
				template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
				routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
