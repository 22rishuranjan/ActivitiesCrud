using Application.Interface;
using Application.Mapper;
using Application.Service;
using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApi.Extension
{
    public static class ApplicationServiceExtension
    {


        public static IServiceCollection ConfigureIoC(this IServiceCollection services, IConfiguration config) {


            //to get xml and json response from api
            services.AddControllers()
                .AddNewtonsoftJson()
                .AddXmlSerializerFormatters();
            

            //setting up db for efcore
            services.AddDbContext<DataContext>(options =>
              options.UseSqlServer(config.GetConnectionString("dev"))
              ,ServiceLifetime.Transient
            );

            // needed to load configuration from appsettings.json
            services.AddOptions();

            // needed to store rate limit counters and ip rules
            services.AddMemoryCache();

            //load general configuration from appsettings.json
            services.Configure<IpRateLimitOptions>(config.GetSection("IpRateLimiting"));
           

            // configuration (resolvers, counter key builders)
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            services.AddScoped<IActivity, ActivityService>();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:3001", "http://localhost:3000");
                       
                });
            });

            return services;
        }
    }
}
