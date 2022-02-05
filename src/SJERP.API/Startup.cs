using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SJERP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SJERP.API.Configuration;
using SJERP.Business.Authentication.Helpers;
using SJERP.Business.Authentication.Middleware;
using SJERP.Business.Authentication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SJERP.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddDbContext<SJERPDbContext>();
        //    services.AddCors();
        //    services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);

        //    //services.AddDbContext<SJERPDbContext>(options =>
        //    //{
        //    //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        //    //});
        //    //services.AddCors();
        //    services.AddAutoMapper(typeof(Startup));
        //    //services.AddControllers();


        //    services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1", new OpenApiInfo { Title = "SJERP.API", Version = "v1" });
        //    });

        //    services.ResolveDependencies();

        //    //services.AddCors(options =>
        //    //{
        //    //    options.AddPolicy(
        //    //      "CorsPolicy",
        //    //      builder => builder.WithOrigins("http://localhost:4200")
        //    //      .AllowAnyMethod()
        //    //      .AllowAnyHeader()
        //    //      .AllowCredentials()
        //    //      .AllowAnyHeader());
        //    //});

        //    // configure strongly typed settings object
        //    services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));


        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //        app.UseSwagger();
        //        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SJERP.API v1"));
        //    }

        //    app.UseHttpsRedirection();

        //    app.UseRouting();

        //    app.UseAuthorization();

        //    //app.UseCors("CorsPolicy");
        //    // global cors policy
        //    app.UseCors(x => x
        //        .SetIsOriginAllowed(origin => true)
        //        .AllowAnyMethod()
        //        .AllowAnyHeader()
        //        .AllowCredentials());

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllers();
        //    });

        //}



        // add services to the DI container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SJERPDbContext>();


            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SJERP.API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(
                  "CorsPolicy",
                  builder => builder.WithOrigins("http://3.86.208.219", "http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());
            });

            services.ResolveDependencies();
            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            //services.AddScoped<IAccountService, AccountService>();
            //services.AddScoped<IEmailService, EmailService>();

            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    options.MinimumSameSitePolicy = SameSiteMode.Strict;

            //});

            #region snippet1
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
            #endregion
        }

        // configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, SJERPDbContext context)
        {

            // migrate database changes on startup (includes initial db creation)
            //context.Database.Migrate();
            app.UseCors("CorsPolicy");
            // generated swagger json and swagger ui middleware
            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", ".NET Sign-up and Verification API"));

            app.UseHttpsRedirection();

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseRouting();



            app.UseAuthentication();
            app.UseAuthorization();
            // global cors policy
            //app.UseCors(x => x
            //    .SetIsOriginAllowed(origin => true)
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials());
      

            app.UseEndpoints(x => x.MapControllers());
        }


    }
}
