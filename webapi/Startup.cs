using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Webapi.Data;
using Webapi.Extensions;
using Webapi.Middleware;
using Webapi.Repositories;
using Webapi.Settings;

namespace Webapi
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
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));
            services.AddSingleton<IMongoClient>(serviceProvider =>
            {
                var settings = Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                return new MongoClient(settings.ConnectionString);
            });

            services.AddDbContext<AppSQLDbContext>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("AppSQLDbEFConnection"));
                }, ServiceLifetime.Singleton
            );
            services.AddDbContext<AppOracleDbContext>(
                options =>
                {
                    options.UseOracle(Configuration.GetConnectionString("AppOracleDbEFConnection"),
                    b =>
                        b.MigrationsAssembly(typeof(AppOracleDbContext).Assembly.FullName)
                        .UseOracleSQLCompatibility("12"));
                },ServiceLifetime.Singleton
            );


            // Add Authentication 
            // this is for Item in memory
            //services.AddSingleton<IItemsRepository, InMemItemRepositories>();

            // this is for Item in Sql Database.

            //services.AddSingleton<IItemsRepository, SqlServerDbItemRepository>();
            services.AddSingleton<IItemsRepository, OracleEFRepository>();
            services.AddSingleton<IStudentRepository,StudentRepo>();

            services.AddSingleton<ISecondRepo, SecondRepo>();
            // End of SQL database.

            // this is for Item Store in Mongo DB. database. 
            //services.AddSingleton<IItemsRepository, MongoDbItemsRepository>();

            // Note: use one of them not both at a time . either InMemItemRepositories or MongoDbItemsRepository

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "webapi", Version = "v1" });
            });

            // register your middleware here.
            services.AddTransient<CustomExceptionMiddleware>();
            services.AddTransient<TestMiddleware>();
            services.AddSingleton<CustomTest>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "webapi v1"));
                app.UseDeveloperExceptionPage();
            }
            else
            {

                // for testing purpose.
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "webapi Production"));
            }

            // we can do gloable exception handler by two way

            // one by Extension Method and other by custom middleware
            // Method 1.
            //app.ConfigureExceptionHandler(env);
            // Method 2
            app.UseMiddleware<CustomExceptionMiddleware>();

            app.UseMiddleware<TestMiddleware>();

            app.UseMiddleware<CustomTest>();
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
