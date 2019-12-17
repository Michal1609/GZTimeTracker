using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GZIT.GZTimeTracker.Infrastructure;
using Microsoft.EntityFrameworkCore;
using GZIT.GZTimeTracker.Infrastructure.Data;
using System.Resources;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using GZIT.GZTimeTracker.Core;
using Microsoft.AspNetCore.Mvc.Localization;
using GZIT.GZTimeTracker.Core.Infrastructure;
using Microsoft.Extensions.Localization;
using GZTimeTracker.Core.Web;
using GZIT.GZTimeTracker.Core.Web;
using GZTimeTracker.Web.Framework.Localizations;
using GZTimeTracker.Web.Framework;
using AutoMapper;
using GZIT.GZTimeTracker.Web.Framwork.Mapping;
using GZTimeTracker.Web.Framework.Role;
using GZIT.GZTimeTracker.Core.Infrastructure.Services;
using GZIT.GZTimeTracker.Infrastructure.Services;
using GZTimeTracker.Web.Framework.Instalation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using GZTimeTracker.Web.Framework.Cache;

namespace GZTimeTracker.Web
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
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton, ServiceLifetime.Singleton); 
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient<IStringLocalizerFactory, Framework.Localizations.StringLocalizerFactory>();
            services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()))
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();
            services.AddHttpContextAccessor();

            // Get allowed languages  
            /*
            var context = services.BuildServiceProvider().GetService<DataContext>();            
            var languages = context.Language.ToList();
            WebWorker.InstalledLanguages = languages;
            CultureInfo[] cultureInfos = new CultureInfo[languages.Count];
            for (int i = 0; i < languages.Count; i++)
            {
                cultureInfos[i] = new CultureInfo(languages[i].Code);
            }
       
            */
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.SupportedCultures = new List<CultureInfo>() { CultureInfo.CurrentCulture };
                options.SupportedUICultures = options.SupportedCultures;
            });
            

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddScoped<ICookiesServices, Framework.Cookies.CookiesServices>();
            services.AddScoped<ILanguageServices, LanguageServices>();
            services.AddScoped<IHtmlLocalizerFactory, Framework.Localizations.HtmlLocalizerFactory>();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton<IRoleServices, RoleServices>();
            services.AddSingleton<IEmailSender, EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            //app.UseAuthorization();
            
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            Installation(app);
            CacheData(app);
        }

        private void Installation(IApplicationBuilder app)
        {
            // Create DB from migrations if not exist
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                //Configuration.GetSection("");
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                var unitOfWork = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var locOptions = serviceScope.ServiceProvider.GetRequiredService<IOptions<RequestLocalizationOptions>>();

                InstallService installService = new InstallService(context, Configuration, unitOfWork, locOptions);
                installService.Install();
                
            }            
        }

        private void CacheData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var unitOfWork = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                CacheService cacheService = new CacheService(unitOfWork);
                cacheService.LoadStartupData();
            }
            
        }
    }
}
