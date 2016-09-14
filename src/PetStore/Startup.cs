using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PetStore.Data;
using PetStore.Data.Repositories;
using PetStore.Data.Repositories.Interfaces;
using PetStore.Data.UnitOfWork;
using PetStore.Models;
using PetStore.ViewModels;
using System.IO;

namespace PetStore
{
    public class Startup
    {
        public IHostingEnvironment HostingEnvironment { get; private set; }
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; private set; }

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            this.HostingEnvironment = hostingEnvironment;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("PetStoreSettings.json");

            Configuration = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddIdentity<UserAccount, UserRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<PetStoreContext,int>()
            .AddUserStore<UserStore<UserAccount, UserRole, PetStoreContext, int>>()
            .AddRoleStore<RoleStore<UserRole, PetStoreContext, int>>()
            .AddDefaultTokenProviders();

            //services.ConfigreCookieAuthentication()

            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<PetStoreContext>(options => options
                    .UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();
            services.AddTransient<PetStoreContextSeedData>();

            //TODO: move out to an external class
            Mapper.Initialize(config =>
            {
                config.CreateMap<AccountFormViewModel, UserAccount>()
                .ForMember(ua => ua.UserName, opt=>opt.MapFrom(p=>p.Email))
                .ReverseMap();

                config.CreateMap<PetFormViewModel, Pet>()
                .ForMember(p=>p.Type,opt => opt.Ignore())
                .ReverseMap();

                config.CreateMap<AddressFormViewModel, UserAddress>().ReverseMap();
            });

            services.AddMvc(config=> 
            {
                //config.Filters.Add(new RequireHttpsAttribute()); //TODO: Wrap with env.IsProduction=true
            })
            .AddJsonOptions(option=> 
            {
                //TODO: Set CamelCase on.
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            PetStoreContextSeedData seeder)
        {
            //loggerFactory.AddConsole();

            //app.UseWelcomePage();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }

            // Enable serving default and static files
            app.UseStaticFiles();

            app.UseStatusCodePages();

            app.UseIdentity();

            // Enable Mvc routes
            app.UseMvc(routes =>
            {
                //routes.MapRoute("areaRoute", "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            seeder.SeedData().Wait();
        }
    }
}
