using AutoMapper;
using DemoEFCore.Repository;
using DemoEFCore.Service;
using DemoEFCore.Service.MapperConfig;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
namespace DemoEFCore
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

            services.AddDbContext<CommonContext>(option =>
                  option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //var dboptions = new DbContextOptionsBuilder<CommonContext>().UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            //;
            //services.AddSingleton(dboptions.Options);
            // AutoMapperConfig
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfiguration());
            });
            config.CreateMapper();

            //注入服务、仓储类
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IVehicleSeriesRepository, VehicleSeriesRepository>();
            services.AddTransient<IVehicleSeriesService, VehicleSeriesService>();
            services.AddAutoMapper();
            services.AddMvc();

            //将swagger添加到middleware
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "DemoAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //允许跨域访问
            app.UseCors(builder =>
               builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod());

            // 使中间件能够将生成的swagger作为json端点
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.

            //启用中间件服务swagger-ui，指定json端点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoAPI V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Vehicles}/{id?}");

            });
        }
    }
}
