using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using da_service.Entities;
using da_service.Repositories;
using da_service.Utils;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace da_service
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var cs = Configuration.GetConnectionString("Default");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(cs));

            services.AddScoped<HeatRepository>();
            services.AddScoped<CSTDataRepository>();
            services.AddScoped<CSTTempRepository>();
            services.AddScoped<GradeRepository>();
            services.AddScoped<LadleRepository>();
            services.AddScoped<EAFDataRepository>();
            
            services.AddScoped<HeatUtils>();
            services.AddScoped<FormatUtils>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            

            app.UseEndpoints(endpoints =>
            {
                var scope = app.ApplicationServices.CreateScope();
                var service = scope.ServiceProvider.GetService<HeatUtils>();
                var formatService = scope.ServiceProvider.GetRequiredService<FormatUtils>();
                
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
                endpoints.MapGet("/heat", async context => { await context.Response.WriteAsync(service.getHeatById(777).Result.Weight.ToString()); });
                endpoints.MapGet("/cstdata", async context => { await context.Response.WriteAsync(service.getCSTDataById(117).Result.HeatId.ToString()); });
                endpoints.MapGet("/heatdiff", async context => { await context.Response.WriteAsync(formatService.getTempDiffForHeatAsJSON(777).Result); });
                endpoints.MapGet("/listgrade", async context => { await context.Response.WriteAsync(formatService.getTempDiffForGradeAsJSON(15).Result); });
                endpoints.MapGet("/gradecsv", async context => { await context.Response.WriteAsync(formatService.getHeatTempDiffForGradeAsCSV(15).Result); });
                //endpoints.MapGet("/list", async context => { await context.Response.WriteAsync(service.getTempDiffListJSON().Result); });
                endpoints.MapGet("/list", async context => { await context.Response.WriteAsync(formatService.getHeatTempDiffAsJSON().Result); });
                endpoints.MapGet("/listcsv", async context => { await context.Response.WriteAsync(formatService.getHeatTempDiffAsCSV().Result); });

                List<int> gradesList = new List<int>(){1,2,3};
                endpoints.MapGet("/listrange", async context => { await context.Response.WriteAsync(formatService.getHeatTempDiffAsJSON(gradesList).Result); });
                endpoints.MapGet("/listcsvrange", async context => { await context.Response.WriteAsync(formatService.getHeatTempDiffAsCSV(gradesList).Result); });
            });
        }
    }
}