using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace NetCore20Auth
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Kimlik Doprulama
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/auth/denied");
                options.Cookie.Domain = "localhost"; // configden site url çekilecek
                options.Cookie.HttpOnly = true; // sadece domain üzerinden erişim olsun. Cross olmasın
                options.Cookie.Name = "VM_UID";
                // options.Cookie.SameSite = SameSiteMode.Strict; //üçüncü taraflara gitmesin  
            }).AddFacebook(options =>
            {
                options.SignInScheme = "ApplicationCookie";
                options.AppId = "533982070312614";
                options.AppSecret = "e33b725a7be8d0975b0cf1ffee2dec25";
                options.Scope.Add("public_profile"); 
                options.Scope.Add("email");
            }) 
            ;

            // Yetkilendirme
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizeEnum.View,
                        policy => policy.Requirements.Add(new LoggingAuthorizationRequirement()));
                options.AddPolicy(AuthorizeEnum.New,
                        policy => policy.Requirements.Add(new LoggingAuthorizationRequirement()));
                options.AddPolicy(AuthorizeEnum.Edit,
                        policy => policy.Requirements.Add(new LoggingAuthorizationRequirement()));
                options.AddPolicy(AuthorizeEnum.Delete,
                        policy => policy.Requirements.Add(new LoggingAuthorizationRequirement()));
                options.AddPolicy(AuthorizeEnum.Save,
                        policy => policy.Requirements.Add(new LoggingAuthorizationRequirement()));

                //policy adding here
            });

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme)
                                .RequireAuthenticatedUser()
                                .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            });


            // services.AddSingleton<IAuthorizationHandler, LoggingAuthorizationHandler>();
            services.AddScoped<IAccountManager, AccountManager>();

            //services
            services.AddSingleton<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
        }
    }
}
