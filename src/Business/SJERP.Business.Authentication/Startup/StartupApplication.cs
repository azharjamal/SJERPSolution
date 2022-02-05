
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SJERP.Infrastructure;

namespace SJERP.Business.Authentication.Startup
{
    public class StartupApplication : IStartupApplication
    {

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IGrandAuthenticationService, CookieAuthenticationService>();
            //services.AddScoped<IApiAuthenticationService, ApiAuthenticationService>();
            //services.AddScoped<IJwtBearerAuthenticationService, JwtBearerAuthenticationService>();
            //services.AddScoped<ITwoFactorAuthenticationService, TwoFactorAuthenticationService>();
            //services.AddScoped<IExternalAuthenticationService, ExternalAuthenticationService>();
            //services.AddScoped<IJwtBearerCustomerAuthenticationService, JwtBearerCustomerAuthenticationService>();
            //services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        }
        public void Configure(IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
        {

        }
        public int Priority => 100;
        public bool BeforeConfigure => false;

    }
}
