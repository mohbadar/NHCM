using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHCM.Application.Infrastructure;
using NHCM.Application.Recruitment.Commands;
using NHCM.Application.Recruitment.Validators;
using NHCM.Persistence;
using NHCM.Persistence.Identity.Infrastructure;
using NHCM.Persistence.Infrastructure.Identity;
using NHCM.WebUI.Areas.Security;
using NHCM.WebUI.Types;

namespace NHCM.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public Assembly SearchQueryValidator { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });



           
            // 1 Antiforgery
            services.AddAntiforgery(options => options.HeaderName = "XSRF-TOKEN");
            


            // 2 Add DbContext
            services.AddDbContext<HCMContext>();


            // 3 Identity

            services.AddDbContext<HCMIdentityDbContext>();

            services.AddIdentity<HCMUser, HCMRole>(options => { options.User.RequireUniqueEmail = true; })
                .AddErrorDescriber<IdentityLocalizedErrorDescribers>()
                .AddEntityFrameworkStores<HCMIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options => {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
               
            });


          

         



            




            // Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
             services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(CreatePersonCommandHandler).GetTypeInfo().Assembly);



            // Add MVC with fluent validation, Razor pages option
            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreatePersonCommandValidator>())
                .AddRazorPagesOptions
                (
                    options =>
                    {

                        // Comment it in production
                         options.Conventions.AllowAnonymousToPage("/Security/Register");

                        options.Conventions.AuthorizeFolder("/Security");
                        options.Conventions.AuthorizeFolder("/Recruitment");
                        options.Conventions.AuthorizeFolder("/Shared");
                        options.Conventions.AuthorizePage("/index");

                        options.AllowMappingHeadRequestsToGetHandler = true;

                    }
                )
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.ConfigureApplicationCookie
                (
                    options =>
                    {
                        options.LoginPath = "/Security/Login";
                    }
                );




        }








        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            // User type extension method used for providing configuration from config file in static methods.
            serviceProvider.SetConfigurationProvider(Configuration);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();
            app.UseMvc();
        }


       
    }
}
