using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Npgsql;
using RT.Reports.BusinessLayer;
using RT.Reports.DataLayer;
using RT.Reports.Domain.Interfaces;
using RT.Reports.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Reports
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RT.Report", Version = "v1" });
            });

            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            var builder = new NpgsqlConnectionStringBuilder(connectionString);
            services.AddDbContext<RTReportsDataContext>(options => options.UseNpgsql(builder.ConnectionString));

            var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MapperBL());
        });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<ICity, CityService>();
            services.AddScoped<ICityBL, CityBL>();
            services.AddScoped<IReport, ReportService>();
            services.AddScoped<IReportBL, ReportBL>();
            services.AddScoped<IReportStatus, ReportStatusService>();
            services.AddScoped<IReportStatusBL, ReportStatusBL>();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RT.Report v1"));
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
