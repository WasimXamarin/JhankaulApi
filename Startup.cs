using JhankaulAPI.Models;
using JhankaulAPI.Repositories;
using JhankaulAPI.RepositoriesMethod;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JhankaulAPI
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
            services.AddControllers();
            services.AddDbContext<JhankaulContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IChiefGuestRepository, ChiefGuestRepository>();
            services.AddScoped<IOrganizerRepository, OrganizerRepository>();
            services.AddScoped<ISignUpRepository, SignUpRepository>();
            services.AddScoped<ISainikRepository, SainikRepository>();
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<IPrizeRepository, PrizeRepository>();
            services.AddScoped<ISignUpMobileRepository, SignUpMobileRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
