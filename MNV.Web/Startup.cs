using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MNV.Core.Database;
using MNV.Database;
using MNV.Domain.ConfigSections;
using MNV.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.OpenApi.Models;
using MNV.Core.Services;
using MNV.Infrastructure.Services;

namespace MNV.Web
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
            services.AddControllers();
            services.AddControllers();


            services.Configure<AppSettings>(Configuration.GetSection(ConfigurationConstants.AppSettings));

            #region JWT
            var appSettings = Configuration.GetSection(ConfigurationConstants.AppSettings).Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                        ClockSkew = TimeSpan.Zero
                    };
                });
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MNV",
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                     {
                      {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                          },
                          new[] { "readAccess", "writeAccess" }
                      }
                     });
            });
            #endregion

            #region Databases
            services.AddHttpContextAccessor();
            var constring = Configuration.GetSection(ConfigurationConstants.ConnectionStrings).Get<ConnectionStrings>();
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<DataContext>(options => options.UseSqlServer(constring.WebApiConnection));
            services.AddTransient<IDataContext>(provider => provider.GetService<DataContext>());
            #endregion

            #region Application Services Configuration
            services.AddTransient<IEncryptionService, EncryptionService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            #endregion

            #region Mediator
            var queryAssembly = AppDomain.CurrentDomain.Load("MNV.Queries");
            var commandAssembly = AppDomain.CurrentDomain.Load("MNV.Commands");
            services.AddMediatR(queryAssembly, commandAssembly);
            #endregion

            #region Automapper
            //AutoMapperConfiguration.Initialize();
            var mapperAssembly = AppDomain.CurrentDomain.Load("MNV.Mappers");
            services.AddAutoMapper(mapperAssembly);
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHsts();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MNV Api v1");
                c.DocumentTitle = "MNV APIs";
                c.DocExpansion(DocExpansion.None);
                c.RoutePrefix = string.Empty;
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
