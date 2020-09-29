using API.Models;
using API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Denne metode bliver kaldt af "the runtime". Metoden bruges til at tilføjer de forskellige services som vi har lavet.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<LabyrinthDatabaseSettings>(
                Configuration.GetSection(nameof(LabyrinthDatabaseSettings)));   // Her kofigurere vi API'ens perspektiv af databasen udfra informationerne i appsettings.json filen.

            services.AddSingleton<ILabyrinthDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<LabyrinthDatabaseSettings>>().Value);

            services.AddSingleton<LabyrinthService>();  // Her oprettes en enkelt instance af LabyrinthService.
            services.AddSingleton<StatisticService>();  // Her oprettes en enkelt instance af StatisticService.

            services.AddControllers();  // Her tilføjes services for controllers.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}