using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using TKDSIM.BLL.Interface;
using TKDSIM.BLL.TKDSIMBLL;
using TKDSIM.DAL.Concrete.EntityFrameworkCore;
using TKDSIM.DAL.Concrete.EntityFrameworkCore.Concrete;
using TKDSIM.DAL.Concrete.EntityFrameworkCore.Interface;

namespace TKDSIM.WebAPI
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

            services.AddScoped<IEfAppealInfoDal, EfAppealInfoDal>();
            services.AddScoped<IAppealInfoBLL, AppealInfoBLL>();

            services.AddScoped<IEfEnumDal, EfEnumDal>();
            services.AddScoped<IEnumBLL, EnumBLL>();

            services.AddScoped<IEfEnumValueDal, EfEnumValueDal>();
            services.AddScoped<IEnumValueBLL, EnumValueBLL>();

            services.AddScoped<IEfLoggerDal, EfLoggerDal>();
            services.AddScoped<ILoggerBLL, LoggerBLL>();

            services.AddScoped<IEfMissingDocsDal, EfMissingDocsDal>();
            services.AddScoped<IMissingDocsBLL, MissingDocsBLL>();

            services.AddScoped<IEfOrderProjectDal, EfOrderProjectDal>();
            services.AddScoped<IOrderProjectBLL, OrderProjectBLL>();

            services.AddScoped<IEfSubmittedDocsDal, EfSubmittedDocsDal>();
            services.AddScoped<ISubmittedDocsBLL, SubmittedDocsBLL>();

            services.AddScoped<IEfUserDal, EfUserDal>();
            services.AddScoped<IUserBLL, UserBLL>();

            services.AddScoped<IEfWorkDoneFormDal, EfWorkDoneFormDal>();
            services.AddScoped<IWorkDoneFormBLL, WorkDoneFormBLL>();

            services.AddScoped<IEfWorkDoneTableDal, EfWorkDoneTableDal>();
            services.AddScoped<IWorkDoneTableBLL, WorkDoneTableBLL>();

            services.AddScoped<IEFAdminUnitDal, EFAdminUnitDal>();
            services.AddScoped<IAdminUnitBLL, AdminUnitBLL>();

            services.AddScoped<IEfAppealInfoDetailDal, EfAppealInfoDetailDal>();
            services.AddScoped<IAppealInfoDetailBLL, AppealInfoDetailBLL>();

            services.AddScoped<IReportBLL, ReportBLL>();

            services.AddDbContext<TKDSIMDBContext>();

            services.AddAutoMapper(typeof(TKDSIM.Core.Mapping.AutoMapper));

            services.AddControllers();
            //services.AddCors(o =>
            //{
            //    o.AddPolicy("Policy1", builder =>
            //     {
            //         builder.WithOrigins("http://localhost:3000/")
            //             .WithMethods("POST", "GET", "PUT", "DELETE")
            //             .WithHeaders(HeaderNames.ContentType);
            //     });
            //});

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options => {
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuerSigningKey = false,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("TkDabcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789SiM")),
                  ValidateIssuer = false,
                  ValidateAudience = false
              };
          });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;
            });

            // Cookie configurations
            services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/auth/login";
                options.LogoutPath = "/auth/logout";
                options.SlidingExpiration = true;

                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".AspNetCore.Security.Cookie",
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseHttpsRedirection();


            app.UseStatusCodePages(context =>{
                var response = context.HttpContext.Response;

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    response.Redirect("/api/Error/Unauthorized");
                }
                return Task.CompletedTask;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

         //   app.UseCors("Policy1");
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
