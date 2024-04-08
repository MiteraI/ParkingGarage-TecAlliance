using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParkingGarage.Domain.Entities;
using ParkingGarage.Security;
using ParkingGarage.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ParkingGarage.Configuration
{
    public static class SecurityStartup
    {
        public static IServiceCollection AddSecurityModule(this IServiceCollection services)
        {
            var opt = services.BuildServiceProvider().GetRequiredService<IOptions<SecuritySettings>>();
            var secret = opt.Value.Authentication.Jwt.Base64Secret;

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.ClaimsIdentity.UserNameClaimType = ClaimTypes.NameIdentifier;
            })
                .AddEntityFrameworkStores<ApplicationDatabaseContext>()
                .AddUserStore<UserStore<User, Role, ApplicationDatabaseContext, string, IdentityUserClaim<string>,
                UserRole, IdentityUserLogin<string>, IdentityUserToken<string>, IdentityRoleClaim<string>>>()
                .AddRoleStore<RoleStore<Role, ApplicationDatabaseContext, string, UserRole, IdentityRoleClaim<string>>>()
                .AddDefaultTokenProviders();

            services
                .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                 .AddJwtBearer(cfg =>
                 {
                     cfg.RequireHttpsMetadata = false;
                     cfg.SaveToken = true;
                     cfg.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(secret)),
                         ClockSkew = TimeSpan.Zero,/// remove delay of token when expire
                         NameClaimType = ClaimTypes.NameIdentifier
                     };
                 });

            services.AddScoped<IPasswordHasher<User>, BCryptPasswordHasher>();
            services.AddScoped<IClaimsTransformation, RoleClaimsTransformation>();
            services.AddScoped<ITokenProvider, TokenProvider>();

            return services;
        }

        public static IApplicationBuilder UseApplicationSecurity(this IApplicationBuilder app,
        SecuritySettings securitySettings)
        {
            app.UseCors(CorsPolicyBuilder(securitySettings.Cors));
            app.UseAuthentication();
            if (securitySettings.EnforceHttps)
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }
            return app;
        }

        private static Action<CorsPolicyBuilder> CorsPolicyBuilder(Cors config)
        {
            return builder =>
            {
                if (!config.AllowedOrigins.Equals("*"))
                {
                    if (config.AllowCredentials)
                    {
                        builder.AllowCredentials();
                    }
                    else
                    {
                        builder.DisallowCredentials();
                    }
                }

                builder.WithOrigins(config.AllowedOrigins)
                    .WithMethods(config.AllowedMethods)
                    .WithHeaders(config.AllowedHeaders)
                    .WithExposedHeaders(config.ExposedHeaders)
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(config.MaxAge));
            };
        }
    }
}
