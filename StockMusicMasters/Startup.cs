using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using StockMusicMasters.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.CookiePolicy;

namespace StockMusicMasters
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
                options.UseSqlServer(
                    Configuration.GetConnectionString("Local")));

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultUI().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            // Inject the music repository
            services.AddTransient<IMusicRepository, MusicRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            app.Use(async (theContext, next) =>
            {
                theContext.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                theContext.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
                theContext.Response.Headers.Add("Pragma", "no-cache");
                theContext.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
                await next();
            });
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
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
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                HttpOnly = HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always,
                MinimumSameSitePolicy = SameSiteMode.None
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}");

                // USER AREA ROUTES

                endpoints.MapAreaControllerRoute(
                    name: "user",
                    areaName: "user",
                    pattern: "user/{controller=userhome}/{action=userindex}/{id?}");

                // ADMIN AREA ROUTES

                endpoints.MapAreaControllerRoute(
                    name: "admin",
                    areaName: "admin",
                    pattern: "admin/{controller=adminhome}/{action=adminindex}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "admin",
                    areaName: "admin",
                    pattern: "admin/{controller=adminhome}/{action=adminindex}/{id?}");

                endpoints.MapRazorPages();
            });

            // Apply migration
            context.Database.Migrate();

            // Seed the database
            SeedData.Seed(app);

            // Create Default Accounts
            CreateDefaultAccounts(app.ApplicationServices, Configuration).Wait();
        }

        public static async Task CreateDefaultAccounts(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] users = { "AdminUser", "StandardUser" };

            foreach(string user in users)
            {
                string username = configuration["Data:" + user + ":Name"];
                string email = configuration["Data:" + user + ":Email"];
                string password = configuration["Data:" + user + ":Password"];
                string role = configuration["Data:" + user + ":Role"];
                if (await userManager.FindByNameAsync(username) == null)
                {
                    if (await roleManager.FindByNameAsync(role) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }

                    IdentityUser appUser = new IdentityUser { UserName = username, Email = email };
                    IdentityResult result = await userManager.CreateAsync(appUser, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(appUser, role);
                    }
                }
            }
        }
    }
}
