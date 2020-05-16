using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PriceManager.IoC;
using SafeTurn.Persistence.DataAccess;
using SafeTurn.Persistence.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Microsoft.AspNetCore.Identity;

namespace PriceManager.Api
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
            PersistenceRegister.RegisterDbContext(services, Configuration);
            RegisterIdentity(services);
            PersistenceRegister.RegisterRepository(services);
            PersistenceRegister.RegisterQueries(services);
            ApplicationRegister.RegisterServices(services);
            InfrastuctureRegister.RegisterInfrastucture(services, Configuration);
            InfrastuctureRegister.RegisterServices(services);
            services.AddControllers();

            // ConfigureJwt(services, Configuration);

        }

        private void RegisterIdentity(IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();
        }

        // private void ConfigureJwt(IServiceCollection services, IConfiguration configuration)
        // {
        //     // jwt wire up
        //     // Get options from app settings
        //     var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

        //     // Configure JwtIssuerOptions
        //     services.Configure<JwtIssuerOptions>(options =>
        //     {
        //         options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
        //         options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
        //         options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        //     });

        //     var tokenValidationParameters = new TokenValidationParameters
        //     {
        //         ValidateIssuer = true,
        //         ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

        //         ValidateAudience = true,
        //         ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

        //         ValidateIssuerSigningKey = true,
        //         IssuerSigningKey = signingKey,

        //         RequireExpirationTime = false,
        //         ValidateLifetime = true,
        //         ClockSkew = TimeSpan.Zero
        //     };

        //     services.AddAuthentication(options =>
        //     {
        //         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        //     }).AddJwtBearer(configureOptions =>
        //     {
        //         configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
        //         configureOptions.TokenValidationParameters = tokenValidationParameters;
        //         configureOptions.SaveToken = true;

        //         configureOptions.Events = new JwtBearerEvents
        //         {
        //             OnAuthenticationFailed = context =>
        //             {
        //                 if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
        //                 {
        //                     context.Response.Headers.Add("Token-Expired", "true");
        //                 }
        //                 return Task.CompletedTask;
        //             }
        //         };
        //     });

        // }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            // Update database on startup
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
                scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>().Database.Migrate();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            //app.UseHttpException();
        }
    }
}
