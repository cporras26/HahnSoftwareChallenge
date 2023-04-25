using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TechnicalChallenge.BLL;
using TechnicalChallenge.Common.Services;
using TechnicalChallenge.Common.Settings;
using TechnicalChallenge.DAL.Repositories;

namespace TechnicalChallenge.API
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
            services.AddOptions();

            services.Configure<TechnicalChallengeSettings>(Configuration);


            
            //Configure containerBuilder
            var builder = new ContainerBuilder();
            builder.Populate(services);

            AddAutofacRegistrations(builder);

            var container = builder.Build();

            //Golvar Exceptions
            TechnicalChallengeSettings settings;

            using (var scope = container.BeginLifetimeScope())
            { 
                settings = scope.Resolve<TechnicalChallengeSettings>();
            }

            services.AddCors(c =>
            {
                c.AddPolicy("myOriginsPolicy", options =>
                {
                    options.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddAutoMapper(typeof(Program));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechnicalChallenge.API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("myOriginsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechnicalChallenge.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });   
        }

        public void ConfigureContainer(ContainerBuilder builder) 
        {
            AddAutofacRegistrations(builder);
        }

        private static void AddAutofacRegistrations(ContainerBuilder builder)
        {
            #region BLL
            builder.RegisterType<TechnicalChallengeBll>().As<ITechnicalChallengeBll>().InstancePerLifetimeScope();
            #endregion

            #region COMMON
            builder.RegisterGeneric(typeof(DbService<>)).As(typeof(IDbService<>)).InstancePerLifetimeScope();

            builder.Register(ctx =>
            {
                var options = ctx.Resolve<IOptions<TechnicalChallengeSettings>>();
                return options.Value;
            }).InstancePerLifetimeScope();

            builder.Register(ctx =>
            {
                var options = ctx.Resolve<TechnicalChallengeSettings>();
                return options.ConnectionStrings;
            }).InstancePerLifetimeScope();

            builder.Register(ctx =>
            {
                var options = ctx.Resolve<TechnicalChallengeSettings>();
                return options.ConnectionStrings.UsersConnectionString;
            }).SingleInstance();
            #endregion

            #region DAL
            builder.RegisterType<UsersRepository>().As<IUsersRepository>().InstancePerLifetimeScope();
            #endregion
        }
    }
}
