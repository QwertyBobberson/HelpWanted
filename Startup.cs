using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HelpWanted.Services;
using HelpWanted.Controllers;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using HelpWanted.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;

namespace HelpWanted
{
    public class Startup
    {
        static string username;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllers();
            services.AddServerSideBlazor();

            // services.AddAuthentication(options =>
            // {
            //     options.DefaultScheme = "Cookies";
            //     options.DefaultChallengeScheme = "oidc";
            // }).AddCookie().AddOpenIdConnect("oidc", options =>
            // {
            //     options.Authority= Environment.GetEnvironmentVariable("OIDC_AUTHORITY");
            //     options.ClientId = Environment.GetEnvironmentVariable("CLIENT_ID");
            //     options.ClientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
                
            //     options.CallbackPath = new PathString("/signin-oidc");

            //     options.ResponseType="code";

            //     options.SaveTokens = true;
            // });

            // services.Configure<ForwardedHeadersOptions>(options =>
            // {
            //     options.ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto;
            //     options.KnownNetworks.Clear();
            //     options.KnownProxies.Clear();
            // });

            // services.AddAuthorization (options =>
            // {
            //     options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.Use((context, next) =>
            {
                context.Request.Scheme = "https";
                return next();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            // app.UseAuthentication();
            // app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                //endpoints.MapDefaultControllerRoute().RequireAuthorization();
            });
        }
    }
}
