using System.Text;
using Core.Models;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Service;
using Service.Interfaces;
using Settings;

namespace Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AuthSettings>(_configuration.GetSection(AuthSettings.SectionName));

            var mySqlConnectionStr = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<AppDbContext>(
                options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    var authSettings = _configuration.GetSection(AuthSettings.SectionName).Get<AuthSettings>();
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authSettings.Issuer,

                        ValidateAudience = true,
                        ValidAudience = authSettings.Audience,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Key)),

                        ValidateLifetime = false
                    };
                });

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddControllers();

            SetUpServices(services);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });
        }

        private static void SetUpServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IService<>), typeof(Service<>));
            services.AddTransient<IAuthService, AuthService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"); });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}