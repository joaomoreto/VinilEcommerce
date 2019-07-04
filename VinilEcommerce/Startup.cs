using System.IO;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using VinilEcommerce.Domain.Commands.SellDisks;
using VinilEcommerce.Domain.Commands.UpdateTableSpotify;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Interfaces;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.ServiceHandler;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetDisksByGenre;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetDisksById;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetSalesByDate;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetSalesById;
using VinilEcommerce.Infrastructure.Service.Interfaces.Spotify;
using VinilEcommerce.Infrastructure.Service.ServiceHandler.Spotify;

namespace VinilEcommerce
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

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Vinyl's Discs E-commerce API",
                    Version = "v1",
                    Description = "",
                    TermsOfService = "Terms Of Service"
                });

                var appEnv = PlatformServices.Default.Application;
                options.IncludeXmlComments(Path.Combine(appEnv.ApplicationBasePath, $"{appEnv.ApplicationName}.xml"));
            });

            services.AddMediatR(typeof(SellDisksCommand).Assembly);
            services.AddMediatR(typeof(GetDisksByGenreCommand).Assembly);
            services.AddMediatR(typeof(GetDisksByIdCommand).Assembly);
            services.AddMediatR(typeof(GetSalesByDateCommand).Assembly);
            services.AddMediatR(typeof(GetSalesByIdCommand).Assembly);
            services.AddMediatR(typeof(UpdateTableSpotifyCommand).Assembly);

            services.AddSingleton<ISpotifyServiceHandler, SpotifyServiceHandler>();

            services.AddScoped<IDisksDataBase>(factory =>
                new DisksDataBaseHandler(Configuration.GetConnectionString("MySqlDbConnection")));

            services.AddAutoMapper();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vinyl's Discs E-commerce API V1");
                });
        }
    }
}
