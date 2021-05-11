using Confitec.Domain.Behavior;
using Confitec.Infra.Contexts;
using Confitec.Infra.Interfaces;
using Confitec.Infra.Repositories.Users;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Reflection;

namespace Confitec
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCaching();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                                  options =>
                                  {
                                      options.AllowAnyOrigin();
                                  });
            });

            var connectionString = Configuration["ConnectionStrings:sqlString"];
            services.AddDbContext<ConfitecDbContext>(opts => opts.UseSqlServer(connectionString), ServiceLifetime.Transient);

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddControllers();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            const string applicationAssemblyName = "Confitec.Application.dll";

            AssemblyName an = AssemblyName.GetAssemblyName(GetPathApplication() + applicationAssemblyName);

            var assembly = Assembly.Load(an);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));            

            services.AddMediatR(assembly);
        }
        private static string GetPathApplication()
        {
            return PlatformServices.Default.Application.ApplicationBasePath.ToString();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
