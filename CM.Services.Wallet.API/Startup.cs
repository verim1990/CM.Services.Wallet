using CM.Services.Wallet.Concrete;
using CM.Services.Wallet.Concrete.Application.CommandHandlers;
using CM.Services.Wallet.Concrete.Application.Validators;
using CM.Services.Wallet.Infrastracture;
using CM.Services.Wallet.Infrastracture.Contexts;
using CM.Shared.Kernel.Others.Sql;
using CM.Shared.Web;
using CM.Shared.Web.Others.FluentValidation;
using CM.Shared.Web.Others.Kong;
using CM.Shared.Web.Others.Redis;
using CM.Shared.Web.Others.Sieve;
using CM.Shared.Web.Others.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CM.Services.Wallet.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppSettings = Configuration.Get<AppSettings>();
        }

        public IConfiguration Configuration { get; }

        public AppSettings AppSettings { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .Initialize<AppSettings>(Configuration, AppSettings.Global.Wallet)
                .IncludeCors(AppSettings.Global.Web.HttpsUrl)
                .IncludeAuthenticationForAPI(AppSettings.Global.Wallet.Name, AppSettings.Global.Identity.LocalUrl)
                .IncludeSqlServer<ApplicationContext>(AppSettings.Global.Sql, AppSettings.Local.Sql, true)
                .IncludeKong(AppSettings.Global.Kong, AppSettings.Local.Kong, AppSettings.Global.Wallet)
                .IncludeKafka(AppSettings.Global.Kafka, AppSettings.Local.Kafka)
                .IncludeSwagger(AppSettings.Local.Swagger, AppSettings.Global.Identity.HttpsUrl)
                .IncludeBus(typeof(CreateUserCommandHandler))
                .IncludeSieve()
                .AddMvc()
                .IncludeFluentValidation(typeof(CreateUserCommandValidator))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            return services.RegisterModules(new InfrastractureAutofacModule(), new ConcreteAutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCorsForCM()
                .UseSwaggerForCM(AppSettings.Local.Swagger)
                .UseAuthenticationForCM()
                .UseResponseWrapperForCM()
                .UseHttpsRedirection()
                .UseMvc();
        }
    }
}
