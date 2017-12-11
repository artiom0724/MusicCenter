using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicCenter.Data;
using MusicCenter.Models;
using MusicCenter.Services;
using Microsoft.AspNetCore.Authentication.Facebook;
using Brik.Security.VkontakteMiddleware;

namespace MusicCenter
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = "784489228379055";
                facebookOptions.AppSecret = "a7683f83ccf132add0ea51884fdf9efb";
            });

            services.AddAuthentication().AddTwitter(twitter =>
            {
                twitter.ConsumerKey = "hN2orQqMoos4FX9qQL32rWRB6";
                twitter.ConsumerSecret = "Ct1JOqv6WzTam7O2EgIv4WYkonQjecHUwtNqWIJt4ftLwP1Zuf";
            });

            services.AddAuthentication().AddGoogle(google =>
            {
                google.ClientId = "953159431162-4kcj8oeh4p9n8abs7rqu672bojaplp1n.apps.googleusercontent.com";
                google.ClientSecret = "TmGLlJYDwueUvJfLmNKIyjgV";
            });

            services.AddAuthentication().AddVK(VK =>
            {
                VK.ClientId = "6104997";
                VK.ClientSecret = "ZsVxEY8O0ez3LHfi5OjO";
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
